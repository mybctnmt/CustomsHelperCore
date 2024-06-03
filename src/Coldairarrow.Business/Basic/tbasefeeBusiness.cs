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
    public class tbasefeeBusiness : BaseBusiness<tbasefee>, ItbasefeeBusiness, ITransientDependency
    {
        private readonly IDatabase _redis;
        public IDbAccessor _db;
        public tbasefeeBusiness(IDbAccessor db, IConnectionMultiplexer redis)
            : base(db)
        {
            _db = db;
            _redis = redis.GetDatabase();
        }

        #region 外部接口

        public async Task<PageResult<tbasefee>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            string cacheKey = "DataList-tbasefee";

            string cachedDataJson = await _redis.StringGetAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedDataJson))
            {
                var cachedData = JsonConvert.DeserializeObject<PageResult<tbasefee>>(cachedDataJson);
                if (cachedData != null)
                {
                    return cachedData;
                }
            }
            var q = GetIQueryable();
            var where = LinqHelper.True<tbasefee>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<tbasefee, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }

            var data = await q.Where(where).GetPageResultAsync(input);
            string dataJson = JsonConvert.SerializeObject(data);
            await _redis.StringSetAsync(cacheKey, dataJson); 
            return data;
        }

        public async Task<tbasefee> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(tbasefee data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(tbasefee data)
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

        [Transactional]
        public async Task<List<tbasefee>> SaveDatas(List<tbasefee> datalist)
        {
            List<tbasefee> main = _db.GetIQueryable<tbasefee>().ToList();
            _db.Delete<tbasefee>(main);
            if (datalist.Count > 0)
                await _db.InsertAsync<tbasefee>(datalist);
            return datalist;
        }
    }
}