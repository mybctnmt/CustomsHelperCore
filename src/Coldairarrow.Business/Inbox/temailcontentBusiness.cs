using Coldairarrow.Entity.Inbox;
using Coldairarrow.IBusiness;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Inbox
{
    public class temailcontentBusiness : BaseBusiness<temailcontent>, ItemailcontentBusiness, ITransientDependency
    {
        public IOperator @operator { get; }
        public temailcontentBusiness(IDbAccessor db, IOperator _operator)
            : base(db)
        {
            @operator = _operator;
        }

        #region 外部接口

        public async Task<PageResult<temailcontent>> GetDataListAsync(PageInput<List<ConditionDTO>> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<temailcontent>();
            if (!input.Search.IsNullOrEmpty())
            {

                foreach (ConditionDTO search in input.Search)
                {
                    //筛选
                    if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
                    {
                        string expression = $@"{search.Condition}.Contains(@0)";
                        var newWhere = DynamicExpressionParser.ParseLambda<temailcontent, bool>(
                           ParsingConfig.Default, false, expression, search.Keyword);
                        where = where.And(newWhere);
                    }
                }
            }
            where = where.And(x => x.CreatorId == @operator.UserId);
            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<temailcontent> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(temailcontent data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(temailcontent data)
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