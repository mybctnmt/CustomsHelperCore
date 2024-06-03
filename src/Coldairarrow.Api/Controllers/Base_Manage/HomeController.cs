using Coldairarrow.Business.Base_Manage;
using Coldairarrow.Entity.Dto;
using Coldairarrow.IBusiness;
using Coldairarrow.IBusiness.WX;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NSwag.Annotations;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Base_Manage
{
    /// <summary>
    /// 首页控制器
    /// </summary>
    [Route("/Base_Manage/[controller]/[action]")]
    [OpenApiTag("主页")]
    public class HomeController : BaseApiController
    {
        readonly IHomeBusiness _homeBus;
        readonly IPermissionBusiness _permissionBus;
        readonly IBase_UserBusiness _userBus;
        readonly IOperator _operator;
        IConfiguration _configuration;
        IWXOperation _operation;
        IConnectionMultiplexer _redis;
        private readonly JwtOptions _jwtOptions;
        public HomeController(
            IHomeBusiness homeBus,
            IPermissionBusiness permissionBus,
            IBase_UserBusiness userBus,
            IOperator @operator,
            IOptions<JwtOptions> jwtOptions,
            IWXOperation operation,
            IConfiguration configuration,
            IConnectionMultiplexer redis
            )
        {
            _homeBus = homeBus;
            _permissionBus = permissionBus;
            _userBus = userBus;
            _operator = @operator;
            _jwtOptions = jwtOptions.Value;
            _operation = operation;
            _configuration = configuration;
            _redis = redis;
        }

        private async Task<List<string>> GetActiveClientIdsAsync()
        {
            try
            {
                var db = _redis.GetDatabase();
                RedisValue[] activeClients = await db.SetMembersAsync("activeClients");
                return activeClients.Select(value => (string)value).ToList();
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// 用户登录(获取token)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<string> SubmitLogin(LoginInputDTO input)
        {
            var userId = await _homeBus.SubmitLoginAsync(input);
            List<string> activeClients = await GetActiveClientIdsAsync();
            if (activeClients.Contains(userId) && userId != "1642824410328993792")
            {
                throw new BusException("当前帐户已登录！");
            }
            var claims = new[]
            {
                new Claim("userId",userId)
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
        [HttpPost]
        public async Task ChangePwd(ChangePwdInputDTO input)
        {
            await _homeBus.ChangePwdAsync(input);
        }

        [HttpPost]
        public async Task<object> GetOperatorInfo()
        {
            var theInfo = await _userBus.GetTheDataAsync(_operator.UserId);
            var permissions = await _permissionBus.GetUserPermissionValuesAsync(_operator.UserId);
            var resObj = new
            {
                UserInfo = theInfo,
                Permissions = permissions
            };

            return resObj;
        }

        [HttpPost]
        public async Task<List<Base_ActionDTO>> GetOperatorMenuList()
        {
            return await _permissionBus.GetUserMenuListAsync(_operator.UserId);
        }
        /// <summary>
        /// 获取openid
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<WXInfoDto> GetOpenId(string code)
        {
            string appid = _configuration["WXApplet:appId"];
            string secret = _configuration["WXApplet:secret"];
            return await _operation.GetOpenid(appid, secret, code);
        }
    }
}