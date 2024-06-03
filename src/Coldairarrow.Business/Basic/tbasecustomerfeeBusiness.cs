using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public class tbasecustomerfeeBusiness : BaseBusiness<tbasecustomerfee>, ItbasecustomerfeeBusiness, ITransientDependency
    {
        public tbasecustomerfeeBusiness(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<PageResult<tbasecustomerfee>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<tbasecustomerfee>();
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
                    var newWhere = DynamicExpressionParser.ParseLambda<tbasecustomerfee, bool>(
                        ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                    where = where.And(newWhere);
                }
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<tbasecustomerfee> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task<string> AddDataAsync(tbasecustomerfee data)
        {
            await InsertAsync(data);
            return data.Id;
        }


        [Transactional]
        public async Task SaveDatas(string cid, List<tbasecustomerfee> datalist)
        {

            await Db.DeleteAsync<tbasecustomerfee>(x => x.CId == cid);

            List<tbasecustomerfee> tbasecustomerfees = datalist;

            foreach (var item in tbasecustomerfees)
            {
                item.CId = cid;
            }

            await Db.InsertAsync(tbasecustomerfees);
        }

        public async Task<string> UpdateDataAsync(tbasecustomerfee data)
        {
            await UpdateAsync(data);
            return data.Id;
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