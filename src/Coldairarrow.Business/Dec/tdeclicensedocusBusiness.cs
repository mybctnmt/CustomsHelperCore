using Coldairarrow.Entity.Dec;
using Coldairarrow.Entity.Nems;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public class tdeclicensedocusBusiness : BaseBusiness<tdeclicensedocus>, ItdeclicensedocusBusiness, ITransientDependency
    {
        public tdeclicensedocusBusiness(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<PageResult<tdeclicensedocus>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<tdeclicensedocus>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<tdeclicensedocus, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<tdeclicensedocus> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(tdeclicensedocus data)
        {
            await InsertAsync(data);
        }
        public async Task AddbusinessIdAsync(tdeclicensedocus data, string userid)
        {
            var invthead = Db.GetIQueryable<tinvthead>().FirstOrDefault(a => a.SeqNo == data.OrderNo);
            var q = GetIQueryable().FirstOrDefault(a => a.DocuCode == "a" && a.OrderNo == invthead.OrderNo);
            if (q != null)
            {
                q.CertCode = data.CertCode;
                await UpdateAsync(q);
            }
            else
            {
                data.OrderNo = invthead.OrderNo;
                data.CreateTime = DateTime.Now;
                data.CreatorId = userid;
                data.Id = IdHelper.GetId();
                await AddDataAsync(data);
            }

        }
        public async Task UpdateDataAsync(tdeclicensedocus data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        #endregion

        #region 私有成员

        #endregion
    }
}