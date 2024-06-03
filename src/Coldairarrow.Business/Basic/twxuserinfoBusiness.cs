using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Entity.DTO;
using Coldairarrow.IBusiness;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Basic
{
    public class twxuserinfoBusiness : BaseBusiness<twxuserinfo>, ItwxuserinfoBusiness, ITransientDependency
    {
        readonly IOperator _operator;
        public twxuserinfoBusiness(IDbAccessor db, IOperator @operator)
            : base(db)
        {
            _operator = @operator;
        }

        #region 外部接口

        public async Task<PageResult<twxuserinfo>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<twxuserinfo>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<twxuserinfo, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<twxuserinfo> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(twxuserinfo data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(twxuserinfo data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        public async Task<twxuserinfo> AccountBind(AccountBindDto accountBindDto)
        {
            accountBindDto.password = accountBindDto.password.ToMD5String();
            var theUser = await Db.GetIQueryable<Base_User>()
                .Where(x => x.UserName == accountBindDto.username && x.Password == accountBindDto.password)
                .FirstOrDefaultAsync();

            if (theUser.IsNullOrEmpty())
                throw new BusException("账号或密码不正确！");

            string userid = theUser.Id;
            twxuserinfo userinfo = Db.GetIQueryable<twxuserinfo>().FirstOrDefault(a => a.OpenId == accountBindDto.openid);
            if (userinfo != null)
            {
                throw new BusException("已绑定信息");
            }
            else
            {
                twxuserinfo data = new twxuserinfo();
                data.Id = IdHelper.GetId();
                data.UserId = userid;
                data.OpenId = accountBindDto.openid;
                int i = await InsertAsync(data);
                if (i > 0)
                {
                    return data;
                }
                else
                {
                    throw new BusException("绑定失败");
                }
            }
        }

        public async Task CancelBind(string openid)
        {
            string userid = _operator.UserId;
            twxuserinfo userinfo = Db.GetIQueryable<twxuserinfo>().First(a => a.OpenId == openid);
            if (userinfo != null)
            {
                await DeleteAsync(userinfo);
            }
            else
            {
                throw new BusException("未找到绑定信息");
            }
        }

        public async Task<twxuserinfo> GetWXToken(string openid)
        {
            return await Db.GetIQueryable<twxuserinfo>().FirstOrDefaultAsync(a => a.OpenId == openid);
        }

        #endregion

        #region 私有成员

        #endregion
    }
}