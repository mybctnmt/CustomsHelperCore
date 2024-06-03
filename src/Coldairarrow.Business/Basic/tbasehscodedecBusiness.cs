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
    public class tbasehscodedecBusiness : BaseBusiness<tbasehscodedec>, ItbasehscodedecBusiness, ITransientDependency
    {
        public tbasehscodedecBusiness(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<PageResult<tbasehscodedec>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<tbasehscodedec>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<tbasehscodedec, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<tbasehscodedec> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(tbasehscodedec data)
        {
            tbasehscodedec tbasehscodedec = Db.GetIQueryable<tbasehscodedec>().Where(a => a.hscode == data.hscode && a.EorI == data.EorI && a.textName == data.textName&&a.snum==data.snum).FirstOrDefault();
            if (tbasehscodedec == null)
            {
                await InsertAsync(data);
            }
        }

        public async Task UpdateDataAsync(tbasehscodedec data)
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