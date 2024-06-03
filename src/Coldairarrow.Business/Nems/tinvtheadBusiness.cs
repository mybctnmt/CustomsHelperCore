using Coldairarrow.Entity.DTO;
using Coldairarrow.Entity.Nems;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Nems
{
    public class tinvtheadBusiness : BaseBusiness<tinvthead>, ItinvtheadBusiness, ITransientDependency
    {
        public tinvtheadBusiness(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<tinvtinfo> GetDecInfo(string orderNo)
        {
            tinvtinfo tinvtinfo = new tinvtinfo();
            tinvthead tinvthead = Db.GetIQueryable<tinvthead>().Where(t => t.OrderNo == orderNo).FirstOrDefault();
            if (!tinvthead.IsNullOrEmpty())
            {
                List<tinvtlist> tinvtlists = await Db.GetIQueryable<tinvtlist>().Where(t => t.OrderNo == orderNo).ToListAsync();
                tinvtinfo.tinvthead = tinvthead;
                tinvtinfo.tinvtlists = tinvtlists;
                return tinvtinfo;
            }
            else
            {
                throw new BusException("未查到该订单号！");
            }
        }
        public async Task<PageResult<tinvthead>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<tinvthead>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<tinvthead, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<tinvthead> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(tinvthead data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(tinvthead data)
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