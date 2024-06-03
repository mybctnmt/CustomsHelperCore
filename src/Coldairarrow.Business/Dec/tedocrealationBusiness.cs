using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public class tedocrealationBusiness : BaseBusiness<tedocrealation>, ItedocrealationBusiness, ITransientDependency
    {
        public tedocrealationBusiness(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<PageResult<tedocrealation>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<tedocrealation>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                string expression = $@"{search.Condition}.Contains(@0)";
                if (search.Condition.Equals("OrderNo"))
                {
                    expression = $@"{"OrderNo"}=@0";
                }
                var newWhere = DynamicExpressionParser.ParseLambda<tedocrealation, bool>(
                    ParsingConfig.Default, false, expression, search.Keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<tedocrealation> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(tedocrealation data)
        {
            tedocrealation data1 = Db.GetIQueryable<tedocrealation>().Where(x => x.OrderNo == data.OrderNo && x.EdocCode == "10000001").FirstOrDefault();
            if (data1 == null)
            {
                await InsertAsync(data);
            }
            else
            {
                data1.EdocID = data.EdocID;
                data1.EdocCode = data.EdocCode;
                data1.EdocFomatType = data.EdocFomatType;
                await UpdateAsync(data1);
            }
        }

        public async Task UpdateDataAsync(tedocrealation data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        public async Task<List<tedocrealation>> GetDataByEdocIDs(List<string> docIds)
        {
            List<tedocrealation> tedocrealations = await Db.GetIQueryable<tedocrealation>().Where(x => docIds.Contains(x.EdocID)).ToListAsync();
            return tedocrealations;
        }

        public async Task SaveDataByEdocCode(tedocrealation data)
        {
            tedocrealation data1 = Db.GetIQueryable<tedocrealation>().Where(x => x.OrderNo == data.OrderNo && x.EdocCode == data.EdocCode).FirstOrDefault();
            if (data1 == null)
            {
                await InsertAsync(data);
            }
            else
            {
                data.Id = data1.Id;
                await UpdateAsync(data);
            }
        }

        public Task<List<tedocrealation>> GetDataListOrderAsync(List<string> Order)
        {
            var q = GetIQueryable();
            var list = q.Where(x=>Order.Contains(x.OrderNo)).ToListAsync();
            return list;
        }

        #endregion

        #region 私有成员

        #endregion
    }
}