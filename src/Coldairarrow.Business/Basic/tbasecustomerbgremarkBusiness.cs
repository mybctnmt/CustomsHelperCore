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
    public class tbasecustomerbgremarkBusiness : BaseBusiness<tbasecustomerbgremark>, ItbasecustomerbgremarkBusiness, ITransientDependency
    {
        public tbasecustomerbgremarkBusiness(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<PageResult<tbasecustomerbgremark>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<tbasecustomerbgremark>();
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
                    var newWhere = DynamicExpressionParser.ParseLambda<tbasecustomerbgremark, bool>(
                        ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                    where = where.And(newWhere);
                }
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<tbasecustomerbgremark> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task<string> AddDataAsync(tbasecustomerbgremark data)
        {
            await InsertAsync(data);
            return data.Id;
        }

        public async Task<string> UpdateDataAsync(tbasecustomerbgremark data)
        {
            await UpdateAsync(data);
            return data.Id;
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        public async Task SaveListData(BgRemarkDto bgRemarkDto)
        {
            await Db.DeleteAsync<tbasecustomerbgremark>(x => x.CId == bgRemarkDto.CId);

            List<tbasecustomerbgremark> tbasecustomerbgremarks = bgRemarkDto.tbasecustomerbgremarks;

            foreach (var item in tbasecustomerbgremarks)
            {
                item.CId = bgRemarkDto.CId;
                item.Name = bgRemarkDto.Name;
            }

            await Db.InsertAsync(tbasecustomerbgremarks);
        }

        #endregion

        #region 私有成员

        #endregion
    }
}