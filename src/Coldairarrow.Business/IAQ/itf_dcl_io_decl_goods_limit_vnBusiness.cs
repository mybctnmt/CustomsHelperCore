using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IAQ
{
    public class itf_dcl_io_decl_goods_limit_vnBusiness : BaseBusiness<itf_dcl_io_decl_goods_limit_vn>, Iitf_dcl_io_decl_goods_limit_vnBusiness, ITransientDependency
    {
        public itf_dcl_io_decl_goods_limit_vnBusiness(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<PageResult<itf_dcl_io_decl_goods_limit_vn>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<itf_dcl_io_decl_goods_limit_vn>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<itf_dcl_io_decl_goods_limit_vn, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<itf_dcl_io_decl_goods_limit_vn> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(itf_dcl_io_decl_goods_limit_vn data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(itf_dcl_io_decl_goods_limit_vn data)
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