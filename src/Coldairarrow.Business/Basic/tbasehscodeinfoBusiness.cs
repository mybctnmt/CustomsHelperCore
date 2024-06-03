using Coldairarrow.Entity.Basic;
using Coldairarrow.Entity.DTO;
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
    public class tbasehscodeinfoBusiness : BaseBusiness<tbasehscodeinfo>, ItbasehscodeinfoBusiness, ITransientDependency
    {
        public tbasehscodeinfoBusiness(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<PageResult<tbasehscodeinfo>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<tbasehscodeinfo>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<tbasehscodeinfo, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<tbasehscodeinfo> GetTheDataAsync(string codets)
        {
            var q = GetIQueryable();
            return await q.FirstOrDefaultAsync(a => a.codets == codets);
        }

        public async Task AddDataAsync(tbasehscodeinfo data)
        {
            tbasehscodeinfo tbasehscodeinfo = Db.GetIQueryable<tbasehscodeinfo>().Where(a => a.codets == data.codets).FirstOrDefault();
            if (tbasehscodeinfo == null)
            {
                await InsertAsync(data);
            }
        }

        public async Task UpdateDataAsync(tbasehscodeinfo data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        public async Task HscodeSync(thscodeinfo thscodeinfo)
        {
            tbasehscodeinfo tbasehscodeinfo = thscodeinfo.tbasehscodeinfo;
            List<tbasehscodedec> tbasehscodedecIs = thscodeinfo.tbasehscodedecIs;
            List<tbasehscodedec> tbasehscodedecEs = thscodeinfo.tbasehscodedecEs;
            Db.Delete<tbasehscodeinfo>(x => x.codets == tbasehscodeinfo.codets);
            Db.Delete<tbasehscodedec>(x => x.hscode == tbasehscodeinfo.codets);

            Db.Insert<tbasehscodeinfo>(tbasehscodeinfo);
            Db.Insert<tbasehscodedec>(tbasehscodedecIs);
            Db.Insert<tbasehscodedec>(tbasehscodedecEs);
        }
        #endregion

        #region 私有成员

        #endregion
    }
}