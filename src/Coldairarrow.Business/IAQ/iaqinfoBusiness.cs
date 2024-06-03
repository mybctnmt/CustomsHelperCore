using Coldairarrow.Business.Dec;
using Coldairarrow.Business.Inbox;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Entity.Inbox;
using Coldairarrow.IBusiness;
using Coldairarrow.IBusiness.IAQ;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{

    public class iaqinfoBusiness : BaseBusiness<iaqinfo>, IiaqinfoBusiness, ITransientDependency
    {
        public IDbAccessor _db;
        public temailorderBusiness _temailorder;
        public IOperator _operator;
        public iaqinfoBusiness(IDbAccessor db, temailorderBusiness temailorder)
            : base(db)
        {
            _temailorder = temailorder;
            _db = db;
        }

        public async Task<iaqinfo> GetIaqInfo(string Unumber)
        {
            iaqinfo iaqinfo = new iaqinfo();
            itf_dcl_io_decl itf_dcl_io_decl = _db.GetIQueryable<itf_dcl_io_decl>().Where(t => t.Unumber == Unumber).FirstOrDefault();
            if (!itf_dcl_io_decl.IsNullOrEmpty())
            {
                List<itf_dcl_io_decl> itf_dcl_io_decls = await _db.GetIQueryable<itf_dcl_io_decl>().Where(t => t.Unumber == Unumber).ToListAsync();
                List<itf_dcl_io_decl_att> itf_dcl_io_decl_atts = await _db.GetIQueryable<itf_dcl_io_decl_att>().Where(t => t.Unumber == Unumber).ToListAsync();
                List<itf_dcl_io_decl_goods> itf_dcl_io_decl_goodss = await _db.GetIQueryable<itf_dcl_io_decl_goods>().Where(t => t.Unumber == Unumber).ToListAsync();
                List<itf_dcl_io_decl_goods_cont> itf_dcl_io_decl_goods_conts = await _db.GetIQueryable<itf_dcl_io_decl_goods_cont>().Where(t => t.Unumber == Unumber).ToListAsync();
                List<itf_dcl_io_decl_goods_limit> itf_dcl_io_decl_goods_limits = await _db.GetIQueryable<itf_dcl_io_decl_goods_limit>().Where(t => t.Unumber == Unumber).ToListAsync();
                List<itf_dcl_io_decl_goods_limit_vn> itf_dcl_io_decl_goods_limit_vns = await _db.GetIQueryable<itf_dcl_io_decl_goods_limit_vn>().Where(t => t.Unumber == Unumber).ToListAsync();
                List<itf_dcl_io_decl_goods_pack> itf_dcl_io_decl_goods_packs = await _db.GetIQueryable<itf_dcl_io_decl_goods_pack>().Where(t => t.Unumber == Unumber).ToListAsync();
                List<itf_dcl_io_decl_ent> itf_dcl_io_decl_ents = await _db.GetIQueryable<itf_dcl_io_decl_ent>().Where(t => t.Unumber == Unumber).ToListAsync();
                List<itf_dcl_io_decl_user> itf_dcl_io_decl_users = await _db.GetIQueryable<itf_dcl_io_decl_user>().Where(t => t.Unumber == Unumber).ToListAsync();
                List<itf_dcl_mark_lob> itf_dcl_mark_lobs = await _db.GetIQueryable<itf_dcl_mark_lob>().Where(t => t.Unumber == Unumber).ToListAsync();
                List<itf_dcl_io_decl_cont_detail> itf_dcl_io_decl_cont_details = await _db.GetIQueryable<itf_dcl_io_decl_cont_detail>().Where(t => t.Unumber == Unumber).ToListAsync();
                iaqinfo.ididOC = itf_dcl_io_decls;
                iaqinfo.ididaOC = itf_dcl_io_decl_atts;
                iaqinfo.ididgOC = itf_dcl_io_decl_goodss;
                iaqinfo.ididgcOC = itf_dcl_io_decl_goods_conts;
                iaqinfo.ididglOC = itf_dcl_io_decl_goods_limits;
                iaqinfo.ididlvOC = itf_dcl_io_decl_goods_limit_vns;
                iaqinfo.ididgpOC = itf_dcl_io_decl_goods_packs;
                iaqinfo.idideOC = itf_dcl_io_decl_ents;
                iaqinfo.ididuOC = itf_dcl_io_decl_users;
                iaqinfo.idmlOC = itf_dcl_mark_lobs;
                iaqinfo.ididcdOC = itf_dcl_io_decl_cont_details;
            }
            else
            {

                return iaqinfo;
                throw new BusException("未查到数据！");
            }
            return iaqinfo;
        }


        protected void InitEntity(object obj)//初始化实体对象的
        {
            if (obj.ContainsProperty("Id"))
                obj.SetPropertyValue("Id", IdHelper.GetId());
            if (obj.ContainsProperty("CreateTime"))
                obj.SetPropertyValue("CreateTime", DateTime.Now);
            if (obj.ContainsProperty("CreatorId"))
                obj.SetPropertyValue("CreatorId", _operator?.UserId);
            if (obj.ContainsProperty("CreatorRealName"))
                obj.SetPropertyValue("CreatorRealName", _operator?.Property?.RealName);
        }

        [Transactional]//事务上下文中执行的
        public async Task SaveIaqInfoAsync(iaqinfo iaqinfo)
        {

            List<itf_dcl_io_decl> ididOC = iaqinfo.ididOC;
            List<itf_dcl_io_decl_att> ididaOC = iaqinfo.ididaOC;
            List<itf_dcl_io_decl_goods> ididgOC = iaqinfo.ididgOC;
            List<itf_dcl_io_decl_goods_cont> ididgcOC = iaqinfo.ididgcOC;
            List<itf_dcl_io_decl_goods_limit> ididglOC = iaqinfo.ididglOC;
            List<itf_dcl_io_decl_goods_limit_vn> ididlvOC = iaqinfo.ididlvOC;
            List<itf_dcl_io_decl_goods_pack> ididgpOC = iaqinfo.ididgpOC;
            List<itf_dcl_io_decl_ent> idideOC = iaqinfo.idideOC;
            List<itf_dcl_io_decl_user> ididuOC = iaqinfo.ididuOC;
            List<itf_dcl_mark_lob> idmlOC = iaqinfo.idmlOC;
            List<itf_dcl_io_decl_cont_detail> ididcdOC = iaqinfo.ididcdOC;
            foreach (var item in ididOC)
            {
                InitEntity(item);
            }
            foreach (var item in ididaOC)
            {
                InitEntity(item);
            }
            foreach (var item in ididgOC)
            {
                InitEntity(item);
            }
            foreach (var item in ididgcOC)
            {
                InitEntity(item);
            }
            foreach (var item in ididglOC)
            {
                InitEntity(item);
            }
            foreach (var item in ididlvOC)
            {
                InitEntity(item);
            }
            foreach (var item in ididgpOC)
            {
                InitEntity(item);
            }
            foreach (var item in idideOC)
            {
                InitEntity(item);
            }
            foreach (var item in ididuOC)
            {
                InitEntity(item);
            }
            foreach (var item in idmlOC)
            {
                InitEntity(item);
            }
            foreach (var item in ididcdOC)
            {
                InitEntity(item);
            }

            //bool isIaqinfo = _db.GetIQueryable<iaqinfo>().Where(t => t.Unumber == iaqinfo.Unumber).Any();

            string Unumber = iaqinfo.Unumber;
            //await _db.DeleteSqlAsync<iaqinfo>(t => t.Unumber == Unumber);
            await _db.DeleteSqlAsync<itf_dcl_io_decl>(t => t.Unumber == Unumber);
            await _db.DeleteSqlAsync<itf_dcl_io_decl_att>(t => t.Unumber == Unumber);
            await _db.DeleteSqlAsync<itf_dcl_io_decl_goods>(t => t.Unumber == Unumber);
            await _db.DeleteSqlAsync<itf_dcl_io_decl_goods_cont>(t => t.Unumber == Unumber);
            await _db.DeleteSqlAsync<itf_dcl_io_decl_goods_limit>(t => t.Unumber == Unumber);
            await _db.DeleteSqlAsync<itf_dcl_io_decl_goods_limit_vn>(t => t.Unumber == Unumber);
            await _db.DeleteSqlAsync<itf_dcl_io_decl_goods_pack>(t => t.Unumber == Unumber);
            await _db.DeleteSqlAsync<itf_dcl_io_decl_ent>(t => t.Unumber == Unumber);
            await _db.DeleteSqlAsync<itf_dcl_io_decl_user>(t => t.Unumber == Unumber);
            await _db.DeleteSqlAsync<itf_dcl_mark_lob>(t => t.Unumber == Unumber);
            await _db.DeleteSqlAsync<itf_dcl_io_decl_cont_detail>(t => t.Unumber == Unumber);
            //await _db.InsertAsync<iaqinfo>(iaqinfo);
            await _db.InsertAsync<itf_dcl_io_decl>(ididOC);
            await _db.InsertAsync<itf_dcl_io_decl_att>(ididaOC);
            await _db.InsertAsync<itf_dcl_io_decl_goods>(ididgOC);
            await _db.InsertAsync<itf_dcl_io_decl_goods_cont>(ididgcOC);
            await _db.InsertAsync<itf_dcl_io_decl_goods_limit>(ididglOC);
            await _db.InsertAsync<itf_dcl_io_decl_goods_limit_vn>(ididlvOC);
            await _db.InsertAsync<itf_dcl_io_decl_goods_pack>(ididgpOC);
            await _db.InsertAsync<itf_dcl_io_decl_ent>(idideOC);
            await _db.InsertAsync<itf_dcl_io_decl_user>(ididuOC);
            await _db.InsertAsync<itf_dcl_mark_lob>(idmlOC);
            await _db.InsertAsync<itf_dcl_io_decl_cont_detail>(ididcdOC);
        }
        //public async Task<PageResult<iaqinfo>> GetDataListAsync(PageInput<ConditionDTO> input)
        //{
        //    var q = GetIQueryable();
        //    var where = LinqHelper.True<iaqinfo>();
        //    var search = input.Search;

        //    //筛选
        //    if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
        //    {
        //        var newWhere = DynamicExpressionParser.ParseLambda<iaqinfo, bool>(
        //            ParsingConfig.Default, false, $@"{search.Condition} == (@0)", search.Keyword);
        //        where = where.And(newWhere);
        //    }

        //    return await q.Where(where).GetPageResultAsync(input);
        //}
        //public async Task DeleteDataAsync(List<string> ids)
        //{
        //    await DeleteAsync(ids);
        //}

    }
}
