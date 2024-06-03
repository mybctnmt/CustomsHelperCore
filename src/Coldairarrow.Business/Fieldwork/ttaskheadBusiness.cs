using Coldairarrow.Entity.Basic;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Entity.Fieldwork;
using Coldairarrow.IBusiness;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Fieldwork
{
    public class ttaskheadBusiness : BaseBusiness<ttaskhead>, IttaskheadBusiness, ITransientDependency
    {
        private IOperator _operator { get; set; }
        public ttaskheadBusiness(IDbAccessor db, IOperator @operator)
            : base(db)
        {
            _operator = @operator;
        }

        #region 外部接口

        public async Task<PageResult<ttaskhead>> GetDataListAsync(TaskHeadInputDto input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<ttaskhead>();

            where = where.AndIf(!input.TaskName.IsNullOrEmpty(), x => x.TaskName.Contains(input.TaskName))
                        .AndIf(!input.TaskContent.IsNullOrEmpty(), x => x.TaskContent.Contains(input.TaskContent))
                        .AndIf(!input.BillNo.IsNullOrEmpty(), x => x.BillNo.Contains(input.BillNo))
                        .AndIf(!input.OrderNo.IsNullOrEmpty(), x => x.OrderNo.Contains(input.OrderNo));

            switch (input.Type)
            {
                case 1:
                    where = where.And(x => x.ReceiverId == null || x.ReceiverId == "");
                    break;
                case 2:
                    where = where.And(x => _operator.Property.AssocIdList.Contains(x.ReceiverId));
                    break;
            }

            int count = await q.Where(where).CountAsync();
            var list = await q.Where(where).OrderBy("IsUrgent Desc")
                .ThenBy("CreateTime Desc")
                .Skip((input.PageIndex - 1) * input.PageRows)
                .Take(input.PageRows)
                .ToListAsync();
            return new PageResult<ttaskhead> { Data = list, Total = count };
        }

        public async Task<ttaskhead> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(ttaskhead data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(ttaskhead data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        public async Task<TaskInfoDto> GetTaskInfo(string id)
        {
            TaskInfoDto taskInfoDto = new TaskInfoDto();
            taskInfoDto.ttaskhead = await Db.GetIQueryable<ttaskhead>().Where(t => t.Id == id).FirstOrDefaultAsync();
            if (taskInfoDto.ttaskhead == null)
            {
                throw new BusException("任务不存在！");
            }
            taskInfoDto.ttaskfeedback = await Db.GetIQueryable<ttaskfeedback>().Where(t => t.TaskId == id).FirstOrDefaultAsync();
            taskInfoDto.ttaskattachments = await Db.GetIQueryable<ttaskattachment>().Where(t => t.TaskId == id).ToListAsync();
            var q = from a in Db.GetIQueryable<ttaskcost>().Where(t => t.TaskId == id)
                    join b in Db.GetIQueryable<tbasefee>() on a.FeeId equals b.Id into ab
                    from b in ab.DefaultIfEmpty()
                    select new ttaskcost
                    {
                        Id = a.Id,
                        CreateTime = a.CreateTime,
                        CreatorId = a.CreatorId,
                        TaskId = a.TaskId,
                        CostName = a.CostName,
                        CostAmount = a.CostAmount,
                        CostType = a.CostType,
                        OrderNo = a.OrderNo,
                        FeeId = a.FeeId,
                        FeeNameCn = b.FeeNameCn
                    };
            taskInfoDto.ttaskcosts = await q.ToListAsync();
            return taskInfoDto;
        }

        public async Task AcceptTaskAsync(string id)
        {
            ttaskhead ttaskhead = await Db.GetIQueryable<ttaskhead>().Where(t => t.Id == id).FirstOrDefaultAsync();
            if (ttaskhead == null)
            {
                throw new BusException("任务不存在！");
            }
            if (!ttaskhead.ReceiverId.IsNullOrEmpty())
            {
                throw new BusException("任务已被接受!");
            }
            ttaskhead.ReceiverId = _operator.UserId;
            ttaskhead.ReceiverName = _operator.Property.RealName;
            ttaskhead.ReceiveTime = DateTime.Now;
            await UpdateAsync(ttaskhead);
        }

        [Transactional]
        public async Task SaveTaskInfo(TaskInfoDto taskInfo)
        {
            ttaskhead ttaskhead = taskInfo.ttaskhead;

            ttaskhead.IsCompleted = true;

            await Db.DeleteAsync<ttaskhead>(t => t.Id == ttaskhead.Id);
            await Db.DeleteAsync<ttaskfeedback>(t => t.TaskId == ttaskhead.Id);
            await Db.DeleteAsync<ttaskattachment>(t => t.TaskId == ttaskhead.Id);
            await Db.DeleteAsync<ttaskcost>(t => t.TaskId == ttaskhead.Id);


            ttaskfeedback ttaskfeedback = taskInfo.ttaskfeedback;
            List<ttaskattachment> ttaskattachments = taskInfo.ttaskattachments;
            List<ttaskcost> ttaskcosts = taskInfo.ttaskcosts;


            await Db.InsertAsync<ttaskhead>(ttaskhead);
            await Db.InsertAsync<ttaskfeedback>(ttaskfeedback);
            await Db.InsertAsync<ttaskattachment>(ttaskattachments);
            await Db.InsertAsync<ttaskcost>(ttaskcosts);
        }

        #endregion

        #region 私有成员

        #endregion
    }
}