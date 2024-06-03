using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public class tbasefiletypeBusiness : BaseBusiness<tbasefiletype>, ItbasefiletypeBusiness, ITransientDependency
    {
        private readonly IDatabase _redis;
        public tbasefiletypeBusiness(IDbAccessor db, IConnectionMultiplexer redis)
            : base(db)
        {
            _redis = redis.GetDatabase();
        }

        #region 外部接口

        public async Task<PageResult<tbasefiletype>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            string cacheKey = "DataList-tbasefiletype";

            string cachedDataJson = await _redis.StringGetAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedDataJson))
            {
                var cachedData = JsonConvert.DeserializeObject<PageResult<tbasefiletype>>(cachedDataJson);
                if (cachedData != null)
                {
                    return cachedData;
                }
            }
            var q = GetIQueryable();
            var where = LinqHelper.True<tbasefiletype>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<tbasefiletype, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }
            var data = await q.Where(where).GetPageResultAsync(input);
            string dataJson = JsonConvert.SerializeObject(data);
            await _redis.StringSetAsync(cacheKey, dataJson);

            return data;
        }

        public async Task<tbasefiletype> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(tbasefiletype data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(tbasefiletype data)
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