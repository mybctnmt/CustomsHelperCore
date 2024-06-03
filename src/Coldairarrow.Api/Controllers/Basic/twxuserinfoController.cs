using Coldairarrow.Business.Basic;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Basic
{
    [Route("/Basic/[controller]/[action]")]
    public class twxuserinfoController : BaseApiController
    {
        #region DI
        private readonly JwtOptions _jwtOptions;

        public twxuserinfoController(IOptions<JwtOptions> jwtOptions, ItwxuserinfoBusiness twxuserinfoBus)
        {
            _jwtOptions = jwtOptions.Value;
            _twxuserinfoBus = twxuserinfoBus;
        }

        ItwxuserinfoBusiness _twxuserinfoBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<twxuserinfo>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _twxuserinfoBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<twxuserinfo> GetTheData(IdInputDTO input)
        {
            return await _twxuserinfoBus.GetTheDataAsync(input.id);
        }
        /// <summary>
        /// 账号绑定
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<string> AccountBind(AccountBindDto accountBindDto)
        {
            twxuserinfo data = await _twxuserinfoBus.AccountBind(accountBindDto);
            var claims = new[]
                {
                    new Claim("userId", data.UserId)
                };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(
                string.Empty,
                string.Empty,
                claims,
                expires: DateTime.Now.AddHours(_jwtOptions.AccessExpireHours),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
        /// <summary>
        /// 账号解绑
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task CancelBind(string openid)
        {
            await _twxuserinfoBus.CancelBind(openid);
        }
        /// <summary>
        /// 通过openid 获取token
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<string> GetWXToken(string openid)
        {
            twxuserinfo twxuser = await _twxuserinfoBus.GetWXToken(openid);
            if (twxuser == null)
            {
                throw new BusException("未找到绑定信息");
            }
            else
            {
                var claims = new[]
                {
                    new Claim("userId", twxuser.UserId)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var jwtToken = new JwtSecurityToken(
                    string.Empty,
                    string.Empty,
                    claims,
                    expires: DateTime.Now.AddHours(_jwtOptions.AccessExpireHours),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(jwtToken);
            }
        }
        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(twxuserinfo data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _twxuserinfoBus.AddDataAsync(data);
            }
            else
            {
                await _twxuserinfoBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _twxuserinfoBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}