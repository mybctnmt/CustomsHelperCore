using Coldairarrow.Entity.Basic;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Entity.Inbox;
using Coldairarrow.Entity.Remind;
using Coldairarrow.IBusiness;
using Coldairarrow.Util;
using EFCore.Sharding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Business
{
    public class AutomaticPollingBusiness : BaseBusiness<temailinfo>, IAutomaticPollingBusiness, ITransientDependency
    {
        public AutomaticPollingBusiness(IDbAccessor db) : base(db)
        {
        }
        public async Task<List<AutomaticDto>> GetQueryData()
        {
            var oneMonthAgo = DateTime.Now.AddMonths(-1);

            var tdecheadQuery = Db.GetIQueryable<tdechead>();
            var query = Db.GetIQueryable<temailorder>()
            .Where(e => e.IsEntryClerk == "1" && e.IsVerifier == "1" && tdecheadQuery.Where(d => d.CusDecStatusName == "保存" && e.CreateTime >= oneMonthAgo).Select(d => d.OrderNo).Contains(e.OrderNo))
            .GroupJoin(tdecheadQuery,
                       e => e.OrderNo,
                       a => a.OrderNo,
                       (e, aGroup) => new { e, aGroup })
            .SelectMany(x => x.aGroup.DefaultIfEmpty(),
                        (x, a) => new AutomaticDto
                        {
                            Id = x.e.Id,
                            OrderNo = x.e.OrderNo,
                            BillNo = a.BillNo,
                            CusVoyageNo = a.CusVoyageNo,
                            TrafName = a.TrafName,
                            IEFlag = a.IEFlag
                        });
            return await query.ToListAsync();
        }
        public async Task<List<AutomaticDto>> GetDetailData()
        {
            var result = from t in Db.GetIQueryable<tdechead>()
                         //where (t.PreEntryId == null && t.CusDecStatus == "10") && t.SeqNo != null
                         where (t.TradeCode == null || t.CusDecStatus == "1") && t.SeqNo != null
                         select new AutomaticDto
                         {
                             BillNo = t.BillNo,
                             SeqNo = t.SeqNo,
                             EncryptString = t.EncryptString,
                             IEFlag = t.IEFlag,
                             OrderNo = t.OrderNo,
                             CreateTime = t.CreateTime,
                             CusDecStatus = t.CusDecStatus,
                             CusDecStatusName = t.CusDecStatusName
                         };
            return await result.OrderByDescending(x => x.CreateTime).ToListAsync();
        }
        public async Task<List<AutomaticDto>> GetStateData()
        {
            var result = from t in Db.GetIQueryable<tdechead>()
                         where (t.CusDecStatus!= "10" && t.CusDecStatus != "1") && t.SeqNo != null
                         select new AutomaticDto
                         {
                             SeqNo = t.SeqNo,
                             EncryptString = t.EncryptString,
                             IEFlag = t.IEFlag,
                             OrderNo = t.OrderNo
                         };
            return await result.ToListAsync();
        }
        /// <summary>
        /// 检查是否满足设定的提醒条件生成提醒记录
        /// </summary>
        /// <returns></returns>
        public async Task<bool> GetDetectionData()
        {
            var result = from a in Db.GetIQueryable<talarmcondition>()
                         join i in Db.GetIQueryable<tbaseinspectionitem>() on a.InspectionItemId equals i.Id into iJoin
                         from i in iJoin.DefaultIfEmpty()
                         join i1 in Db.GetIQueryable<tbaseinspectionitem>() on a.TimeNode equals i1.Id into i1Join
                         from i1 in i1Join.DefaultIfEmpty()
                         where a.IsEnable == "True"
                         select new
                         {
                             a,
                             iTriggerConditions = i.TriggerConditions,
                             iDescriptionName = i.DescriptionName,
                             iTableName = i.TableName,
                             iFieldName = i.FieldName,
                             iFieldType = i.FieldType,
                             iFieldValue = i.FieldValue,
                             iCondition = i.Condition,
                             i1TriggerConditions = i1.TriggerConditions,
                             i1DescriptionName = i1.DescriptionName,
                             i1TableName = i1.TableName,
                             i1FieldName = i1.FieldName,
                             i1FieldType = i1.FieldType,
                             i1FieldValue = i1.FieldValue,
                             i1Condition = i1.Condition
                         };

            var resultToList = result.ToListAsync();
            StringBuilder sb = new StringBuilder();
            foreach (var item in resultToList.Result)
            {
                if (item.a.Type == "1")
                {
                    sb.Append(@$"INSERT   INTO treminderrecord (ItemId, UserTag, ReminderLevel, ReminderMethod, OrderNo,CreateTime) 
                                select DISTINCT
                                '{item.a.Id}' as ItemId, 
                                '{item.a.UserTag}' as UserTag,
                                '{item.a.ReminderLevel}' as ReminderLevel , 
                                '{item.a.ReminderMethod}' as ReminderMethod ,
                                 {item.iTableName}.orderNo,
                                '{DateTime.Now.ToString()}' as CreateTime 
                                from  {item.iTableName} 
                                LEFT JOIN treminderrecord ON treminderrecord.ItemId = '{item.a.Id}' AND treminderrecord.OrderNo = {item.iTableName}.orderNo
                                where 
                                {item.iFieldName}{item.iCondition}'{item.iFieldValue}' 
                                {(item.iTriggerConditions == 1 ? " AND temailorder.IsVerifier='1'  AND temailorder.OrderNo IN (SELECT OrderNo FROM tdechead WHERE CusDecStatus = '1')  " : "")} 
                                 AND treminderrecord.ItemId IS NULL; ");
                }

                if (item.a.Type == "2")
                {
                    sb.Append(@$"INSERT   INTO treminderrecord (ItemId, UserTag, ReminderLevel, ReminderMethod, OrderNo,CreateTime) 
                                select  DISTINCT
                                '{item.a.Id}' as ItemId, 
                                '{item.a.UserTag}' as UserTag,
                                '{item.a.ReminderLevel}' as ReminderLevel , 
                                '{item.a.ReminderMethod}' as ReminderMethod ,
                                {item.i1TableName}.orderNo,
                                '{DateTime.Now.ToString()}' as CreateTime 
                                 {(item.i1TableName == item.iTableName ? $"from  {item.i1TableName}" : $"from  { item.i1TableName} left join { item.iTableName} on { item.i1TableName}.OrderNo ={ item.iTableName}.OrderNo") }     
                                LEFT JOIN treminderrecord ON treminderrecord.ItemId = '{item.a.Id}' 
                                AND treminderrecord.OrderNo = {item.iTableName}.orderNo
                                where 
                              {(item.i1FieldType == "string" ? $"{item.i1TableName}.{item.i1FieldName}{item.i1Condition}'{item.i1FieldValue}'" : $"DATE_ADD({item.i1TableName}.{item.i1FieldName}, INTERVAL {(item.a.PriorDate == "前" ? "-" : "")}{item.a.TimeValue} {(item.a.TimeType == "天" ? "DAY" : "HOUR")}) {(item.a.PriorDate == "前" ? ">" : "<")} NOW() ")}  
                                {(item.iTriggerConditions == 1 ? " and temailorder.IsVerifier='1' " : "")} 
                                AND  {item.iTableName}.{item.iFieldName} {(item.a.ExamType == "是否存在" ? $" <> null and {item.iTableName}.{item.iFieldName} <>''" : $"{item.iCondition} '{item.iFieldValue}'")}  
                                {(item.iTriggerConditions == 4 ? " and tdechead.CusDecStatusName != '结关' " : "")} 
                                {(item.a.TimeInterval!=null? $" AND  (treminderrecord.ItemId IS NULL || DATE_ADD(treminderrecord.CreateTime, INTERVAL {item.a.TimeInterval} HOUR ) < NOW() )": " AND treminderrecord.ItemId IS NULL")}; ");
                }


            }

            return await Task.Run(() => Db.ExecuteSql(sb.ToString()) > -1);
        }

        public async Task<List<RemindRecordDto>> GetUserRemindRecord(string userId)
        {
            var data = Db.GetIQueryable<treminderrecord>();
            var result = Db.GetIQueryable<treminderuserlog>().FirstOrDefault(a => a.UId == userId);
            if (result != null)
            {
                data = Db.GetIQueryable<treminderrecord>().Where(a => a.Id > result.RId);
            }
            else
            {
                result = new treminderuserlog();
                result.UId = userId;
                result.RId = 0;
                result.Id = Guid.NewGuid().ToString();
                result.CreateTime = DateTime.Now;
                await Db.InsertAsync(result);
            }

            var resultData = from t in data
                             join i in Db.GetIQueryable<tdechead>() on t.OrderNo equals i.OrderNo into iJoin
                             from i in iJoin.DefaultIfEmpty()
                             select new RemindRecordDto
                             {
                                 UserTag = t.UserTag,
                                 ReminderLevel = t.ReminderLevel,
                                 ReminderMethod = t.ReminderMethod,
                                 OrderNo = t.OrderNo,
                                 BillNo = i.BillNo,
                                 OwnerCode = i.OwnerCode,
                                 OwnerName = i.OwnerName,
                                 CreateTime = t.CreateTime
                             };
            var datas = await resultData.ToListAsync();

            if (data.Count() > 0)
            {
                result.RId = data.Max(a => a.Id);
            }

            await Db.UpdateAsync(result);
            return datas;
        }
        public async Task<List<RemindRecordDto>> GetRemindRecord()
        {
            var data = Db.GetIQueryable<treminderrecord>().OrderByDescending(a => a.Id).Take(1000);



            var resultData = from t in data
                             join i in Db.GetIQueryable<tdechead>() on t.OrderNo equals i.OrderNo into iJoin
                             from i in iJoin.DefaultIfEmpty()
                             select new RemindRecordDto
                             {
                                 UserTag = t.UserTag,
                                 ReminderLevel = t.ReminderLevel,
                                 ReminderMethod = t.ReminderMethod,
                                 OrderNo = t.OrderNo,
                                 BillNo = i.BillNo,
                                 OwnerCode = i.OwnerCode,
                                 OwnerName = i.OwnerName,
                                 CreateTime = t.CreateTime
                             };
            var datas = await resultData.ToListAsync();
            return datas;
        }

        public async Task<List<AutomaticDto>> GetDetailDataAll(string flag)
        {

            var result = from t in Db.GetIQueryable<temailorder>()
                         join i in Db.GetIQueryable<tdechead>() on t.OrderNo equals i.OrderNo into iJoin
                         from i in iJoin.DefaultIfEmpty()
                         where t.Subject == "单一窗口自动生成" && i.IEFlag == flag && i.ChkSurety == "1"
                         select new AutomaticDto
                         {
                            BillNo = i.BillNo,
                            SeqNo = i.SeqNo,
                            EncryptString = i.EncryptString,
                            IEFlag = i.IEFlag,
                            OrderNo = i.OrderNo
                         };
            return await result.ToListAsync();
        }
    }
}
