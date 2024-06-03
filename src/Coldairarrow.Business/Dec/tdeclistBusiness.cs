using Coldairarrow.Entity.Dec;
using Coldairarrow.Entity.DTO;
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
    public class tdeclistBusiness : BaseBusiness<tdeclist>, ItdeclistBusiness, ITransientDependency
    {
        public tdeclistBusiness(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<PageResult<tdeclist>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<tdeclist>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<tdeclist, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPageResultAsync(input);
        }
        public async Task<List<tdeclist>> GNameQueryAsync(string OwnerCode, string GName, string CodeTS)
        {
            var result = (from a in Db.GetIQueryable<tdechead>()
                          join l in Db.GetIQueryable<tdeclist>() on a.OrderNo equals l.OrderNo
                          where a.OwnerCode == OwnerCode && l.GName == GName && l.CodeTS == CodeTS
                          select l)
              .ToListAsync(); // 异步执行查询并转换为列表

            var distinctResult = (await result)
                          .GroupBy(l => new { l.GName, l.CodeTS, l.GModel }) // 在内存中根据 GName 和 CodeTS 分组
                          .Select(g => g.FirstOrDefault()) // 从每个分组中选取第一个元素
                          .Take(50) // 取前 50 条记录
                          .ToList(); // 在内存中转换为列表

            return distinctResult;
        }
        public async Task<tdeclist> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(tdeclist data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(tdeclist data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        public async Task<List<tdeclist>> GetDataByCodeTS(CodeTSDTO codeTSDTO)
        {
            List<string> orderNos = await Db.GetIQueryable<tdechead>().Where(x => x.TradeName == codeTSDTO.TradeName).Select(x => x.OrderNo).ToListAsync();
            List<tdeclist> tdeclists = await Db.GetIQueryable<tdeclist>().Where(x => orderNos.Contains(x.OrderNo) && codeTSDTO.CodeTSs.Contains(x.CodeTS)).Select(x => new tdeclist
            {
                Id = x.Id,
                GNo = x.GNo,
                DeclPrice = x.DeclPrice,
                CodeTS = x.CodeTS,
                TradeCurr = x.TradeCurr
            }).ToListAsync();
            return tdeclists;
        }

        #endregion

        #region 私有成员

        #endregion
    }
}