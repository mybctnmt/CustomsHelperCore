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
    public class tbasecustomercontactsBusiness : BaseBusiness<tbasecustomercontacts>, ItbasecustomercontactsBusiness, ITransientDependency
    {
        private readonly IDatabase _redis;
        public tbasecustomercontactsBusiness(IDbAccessor db, IConnectionMultiplexer redis)
            : base(db)
        {
            _redis = redis.GetDatabase();
        }

        #region 外部接口

        public async Task<PageResult<tbasecustomercontacts>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            //string cacheKey = "DataList-tbasecustomercontacts";

            //string cachedDataJson = await _redis.StringGetAsync(cacheKey);
            //if (!string.IsNullOrEmpty(cachedDataJson))
            //{
            //    var cachedData = JsonConvert.DeserializeObject<PageResult<tbasecustomercontacts>>(cachedDataJson);
            //    if (cachedData != null)
            //    {
            //        return cachedData;
            //    }
            //}
            var q = GetIQueryable();
            var where = LinqHelper.True<tbasecustomercontacts>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                if (search.Condition == "CId")
                {
                    where = where.And(x => x.CId == search.Keyword);
                }
                else
                {
                    var newWhere = DynamicExpressionParser.ParseLambda<tbasecustomercontacts, bool>(
                        ParsingConfig.Default, false, $@"{search.Condition} = @0", search.Keyword);
                    where = where.And(newWhere);
                }
            }
            var data = await q.Where(where).GetPageResultAsync(input);
            //string dataJson = JsonConvert.SerializeObject(data);
            //await _redis.StringSetAsync(cacheKey, dataJson);


            return data;
        }

        public async Task<tbasecustomercontacts> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task<string> AddDataAsync(tbasecustomercontacts data)
        {
            await InsertAsync(data);
            return data.Id;
        }

        public async Task<string> UpdateDataAsync(tbasecustomercontacts data)
        {
            await UpdateAsync(data);
            return data.Id;
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        public async Task SaveDatas(string cid, List<tbasecustomercontacts> datalist)
        {
            await Db.DeleteAsync<tbasecustomercontacts>(x => x.CId == cid);

            List<tbasecustomercontacts> tbasecustomercontacts = datalist;

            foreach (var item in tbasecustomercontacts)
            {
                item.CId = cid;
            }

            await Db.InsertAsync(tbasecustomercontacts);
        }

        #endregion

        #region 私有成员

        #endregion
    }
}