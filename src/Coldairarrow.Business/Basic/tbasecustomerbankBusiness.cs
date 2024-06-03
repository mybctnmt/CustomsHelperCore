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
    public class tbasecustomerbankBusiness : BaseBusiness<tbasecustomerbank>, ItbasecustomerbankBusiness, ITransientDependency
    {
        public tbasecustomerbankBusiness(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<PageResult<tbasecustomerbank>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<tbasecustomerbank>();
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
                    var newWhere = DynamicExpressionParser.ParseLambda<tbasecustomerbank, bool>(
                        ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                    where = where.And(newWhere);
                }
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<tbasecustomerbank> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task<string> AddDataAsync(tbasecustomerbank data)
        {
            await InsertAsync(data);
            return data.Id;
        }


        [Transactional]
        public async Task<List<tbasecustomerbank>> SaveDatas(List<tbasecustomerbank> datalist)
        {
            List<tbasecustomerbank> bankreturnlist = new List<tbasecustomerbank>();
            foreach (tbasecustomerbank data in datalist) 
            {
                if (data.Id.IsNullOrEmpty())
                {
                    data.Id = IdHelper.GetId();
                    await InsertAsync(data);
                }
                else
                {
                    await UpdateAsync(data);
                }
                bankreturnlist.Add(data);
            }   
            return bankreturnlist;
        }

        public async Task<string> UpdateDataAsync(tbasecustomerbank data)
        {
            await UpdateAsync(data);
            return data.Id;
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        public async Task SaveDatas(string cid, List<tbasecustomerbank> data)
        {
            await Db.DeleteAsync<tbasecustomerbank>(x => x.CId == cid);


            List<tbasecustomerbank> tbasecustomerbanks = data;

            foreach (var item in tbasecustomerbanks)
            {
                item.CId = cid;
            }

            await Db.InsertAsync(tbasecustomerbanks);
        }

        #endregion

        #region 私有成员

        #endregion
    }
}