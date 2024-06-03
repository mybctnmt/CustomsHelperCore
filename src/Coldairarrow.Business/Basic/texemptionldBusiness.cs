using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public class texemptionldBusiness : BaseBusiness<texemptionld>, ItexemptionldBusiness, ITransientDependency
    {
        private readonly IDatabase _redis;
        public texemptionldBusiness(IDbAccessor db, IConnectionMultiplexer redis)
            : base(db)
        {
            _redis = redis.GetDatabase();
        }

        #region 外部接口

        public async Task<PageResult<texemptionld>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            // Generate a unique cache key based on the input
            string cacheKey = "DataList-texemptionld";

            // Try to get the cached data
            string cachedDataJson = await _redis.StringGetAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedDataJson))
            {
                // Deserialize the JSON back to the PageResult<texemptionld> object
                var cachedData = JsonConvert.DeserializeObject<PageResult<texemptionld>>(cachedDataJson);
                if (cachedData != null)
                {
                    return cachedData;
                }
            }

            var where = LinqHelper.True<texemptionld>();
            var search = input.Search;

            // Apply filters if any
            if (!string.IsNullOrEmpty(search.Condition) && !string.IsNullOrEmpty(search.Keyword))
            {
                var newWhere = DynamicExpressionParser.ParseLambda<texemptionld, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }

            // Fetch data from the database
            var data = await GetIQueryable().Where(where).GetPageResultAsync(input);

            // Serialize the data to JSON and store it in Redis
            string dataJson = JsonConvert.SerializeObject(data);
            await _redis.StringSetAsync(cacheKey, dataJson); // Set the expiry as needed

            return data;
        }

        public async Task<texemptionld> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(texemptionld data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(texemptionld data)
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