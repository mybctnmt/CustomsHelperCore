using Coldairarrow.Entity.Base_Manage;
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
    public class TbasecustomerrelationBusiness : BaseBusiness<tbasecustomerrelation>, ItbasecustomerrelationBusiness, ITransientDependency
    {
        public TbasecustomerrelationBusiness(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<PageResult<tbasecustomerrelation>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<tbasecustomerrelation>();
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
                    var newWhere = DynamicExpressionParser.ParseLambda<tbasecustomerrelation, bool>(
                        ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                    where = where.And(newWhere);
                }
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<tbasecustomerrelation> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(tbasecustomerrelation data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(tbasecustomerrelation data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }


        [Transactional]
        public async Task SaveDatas(string cid, List<tbasecustomerrelation> datalist)
        {
            await Db.DeleteAsync<tbasecustomerrelation>(x => x.CId == cid);

            List<Base_User> users = await Db.GetIQueryable<Base_User>().ToListAsync();

            List<tbasecustomerrelation> tbasecustomerbgremarks = datalist;

            foreach (var item in tbasecustomerbgremarks)
            {
                item.CId = cid;
                item.DId = users.Where(u => u.Id == item.UId).FirstOrDefault()?.DepartmentId;
            }

            await Db.InsertAsync(tbasecustomerbgremarks);
        }


        #endregion

        #region 私有成员

        #endregion
    }
}