using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Base_Manage
{
    public class Base_DispatchBusiness : BaseBusiness<Base_Dispatch>, IBase_DispatchBusiness, ITransientDependency
    {
        public Base_DispatchBusiness(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<PageResult<Base_Dispatch>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<Base_Dispatch>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<Base_Dispatch, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<Base_Dispatch> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }
        public async Task<Base_Dispatch> GetOneDataAsync(string id)
        {
            var q = GetIQueryable();
            return await q.FirstOrDefaultAsync(a => a.DispatchId == id);
        }
        public async Task AddDataAsync(Base_Dispatch data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(Base_Dispatch data)
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