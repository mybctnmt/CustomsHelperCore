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
    public class tdetectioncontentBusiness : BaseBusiness<tdetectioncontent>, ItdetectioncontentBusiness, ITransientDependency
    {
        private readonly IDatabase _redis;
        public tdetectioncontentBusiness(IDbAccessor db, IConnectionMultiplexer redis)
            : base(db)
        {
            _redis = redis.GetDatabase();
        }

        #region 外部接口

        public async Task<PageResult<tdetectioncontent>> GetDataListAsync(PageInput<List<ConditionDTO>> input)
        {
            string cacheKey = "DataList-tdetectioncontent";

            string cachedDataJson = await _redis.StringGetAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedDataJson))
            {
                var cachedData = JsonConvert.DeserializeObject<PageResult<tdetectioncontent>>(cachedDataJson);
                if (cachedData != null)
                {
                    return cachedData;
                }
            }
            var q = GetIQueryable();
            var where = LinqHelper.True<tdetectioncontent>();

            foreach (ConditionDTO search in input.Search)
            {
                //筛选
                if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
                {
                    var newWhere = DynamicExpressionParser.ParseLambda<tdetectioncontent, bool>(
                        ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                    where = where.And(newWhere);
                }
            }
            var data = await q.Where(where).GetPageResultAsync(input);
            string dataJson = JsonConvert.SerializeObject(data);
            await _redis.StringSetAsync(cacheKey, dataJson);

            return data;
        }

        public async Task<tdetectioncontent> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(tdetectioncontent data)
        {
            await InsertAsync(data);
            await RefreshCacheAsync();
        }

        public async Task UpdateDataAsync(tdetectioncontent data)
        {
            await UpdateAsync(data);
            await RefreshCacheAsync();
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
            await RefreshCacheAsync();
        }

        public async Task SaveListAsync(List<tdetectioncontent> tdetectioncontents)
        {
            await InsertAsync(tdetectioncontents);
            await RefreshCacheAsync();
        }
        private async Task RefreshCacheAsync()
        {
            string cacheKey = "DataList-tdetectioncontent";
            await _redis.KeyDeleteAsync(cacheKey);
        }
        #endregion

        #region 私有成员

        #endregion
    }
}