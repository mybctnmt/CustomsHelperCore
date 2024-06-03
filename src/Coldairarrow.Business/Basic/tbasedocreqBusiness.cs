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
    public class tbasedocreqBusiness : BaseBusiness<tbasedocreq>, ItbasedocreqBusiness, ITransientDependency
    {
        private readonly IDatabase _redis;
        public tbasedocreqBusiness(IDbAccessor db, IConnectionMultiplexer redis)
            : base(db)
        {
            _redis = redis.GetDatabase();
        }

        #region 外部接口

        public async Task<PageResult<tbasedocreq>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            string cacheKey = "DataList-tbasedocreq";

            string cachedDataJson = await _redis.StringGetAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedDataJson))
            {
                var cachedData = JsonConvert.DeserializeObject<PageResult<tbasedocreq>>(cachedDataJson);
                if (cachedData != null)
                {
                    return cachedData;
                }
            }
            var q = GetIQueryable();
            var where = LinqHelper.True<tbasedocreq>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<tbasedocreq, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }
            var data = await q.Where(where).GetPageResultAsync(input);
            string dataJson = JsonConvert.SerializeObject(data);
            await _redis.StringSetAsync(cacheKey, dataJson);
            return data;
        }

        public async Task<tbasedocreq> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(tbasedocreq data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(tbasedocreq data)
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