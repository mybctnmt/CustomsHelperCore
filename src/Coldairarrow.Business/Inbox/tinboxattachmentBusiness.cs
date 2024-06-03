using Coldairarrow.Entity.Inbox;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Inbox
{
    public class tinboxattachmentBusiness : BaseBusiness<tinboxattachment>, ItinboxattachmentBusiness, ITransientDependency
    {
        public tinboxattachmentBusiness(IDbAccessor db)
            : base(db)
        {
        }

        #region 外部接口

        public async Task<PageResult<tinboxattachment>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<tinboxattachment>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<tinboxattachment, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPageResultAsync(input);
        }
        public async Task<List<tinboxattachment>> GetDataListIDSAsync(List<string> ids)
        {
            var q = GetIQueryable();  

            return await q.Where(a => ids.Contains(a.InboxId)).ToListAsync();
        }
        public async Task<tinboxattachment> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(tinboxattachment data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(tinboxattachment data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        public async Task<List<tinboxattachment>> GetAttachmentList(string orderNo)
        {
            temailorder temailorder = Db.GetIQueryable<temailorder>().Where(x => x.OrderNo == orderNo).FirstOrDefault();
            if (!temailorder.IsNullOrEmpty())
            {
                return await Db.GetIQueryable<tinboxattachment>().Where(x => x.InboxId == temailorder.InboxId).ToListAsync();
            }
            else
            {
                return new List<tinboxattachment>();
            }
        }

        #endregion

        #region 私有成员

        #endregion
    }
}