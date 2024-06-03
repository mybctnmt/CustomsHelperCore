using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public class tbaseexchangeratesBusiness : BaseBusiness<tbaseexchangerates>, ItbaseexchangeratesBusiness, ITransientDependency
    {
        private readonly IDatabase _redis;
        public tbaseexchangeratesBusiness(IDbAccessor db, IConnectionMultiplexer redis)
            : base(db)
        {
            _redis = redis.GetDatabase();
        }

        #region 外部接口

        public async Task<PageResult<tbaseexchangerates>> GetDataListAsync(PageInput<List<ConditionDTO>> input)
        {
            string cacheKey = "DataList-tbaseexchangerates";

            string cachedDataJson = await _redis.StringGetAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedDataJson))
            {
                var cachedData = JsonConvert.DeserializeObject<PageResult<tbaseexchangerates>>(cachedDataJson);
                if (cachedData != null)
                {
                    return cachedData;
                }
            }
            var q = GetIQueryable();
            var where = LinqHelper.True<tbaseexchangerates>();
            if (!input.Search.IsNullOrEmpty())
            {

                foreach (ConditionDTO search in input.Search)
                {
                    //筛选
                    if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
                    {
                        string expression = $@"{search.Condition}.Contains(@0)";
                        if (search.Condition.Equals("StartTime"))
                        {
                            expression = $@"{"SendTime"}>=@0";
                        }
                        if (search.Condition.Equals("EndTime"))
                        {
                            expression = $@"{"SendTime"}<@0";
                        }
                        if (search.Condition.Equals("NoCusDecStatusName"))
                        {
                            expression = $@"{"CusDecStatusName"}!=@0";
                        }
                        if (search.Condition.Equals("CreateTime"))
                        {
                            expression = $@"{"CreateTime"}>@0";
                            search.Keyword = Convert.ToDateTime(search.Keyword).ToString();
                        }
                        var newWhere = DynamicExpressionParser.ParseLambda<tbaseexchangerates, bool>(
                           ParsingConfig.Default, false, expression, search.Keyword);
                        where = where.And(newWhere);
                    }
                }
            }
            var data = await q.Where(where).GetPageResultAsync(input);
            string dataJson = JsonConvert.SerializeObject(data);
            await _redis.StringSetAsync(cacheKey, dataJson);
            return data;
        }

        public async Task<tbaseexchangerates> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(tbaseexchangerates data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(tbaseexchangerates data)
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