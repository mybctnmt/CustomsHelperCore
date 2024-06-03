using Coldairarrow.Entity.Dto;
using Coldairarrow.IBusiness;
using Coldairarrow.IBusiness.WX;
using Coldairarrow.Util;
using EFCore.Sharding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Coldairarrow.Business.WX
{
    public class WXOperation : IWXOperation, ITransientDependency
    {
        public HttpClient _httpClient;

        public WXOperation(HttpClient httpClient)

        {
            _httpClient = httpClient;

        }
        public string GetAuthorizeUrl(string appId, string redirectUrl, string state = "state", string scope = "snsapi_base", string responseType = "code")
        {
            if (!string.IsNullOrEmpty(redirectUrl))
            {
                redirectUrl = HttpUtility.UrlEncode(redirectUrl, System.Text.Encoding.UTF8);
            }
            else
            {
                redirectUrl = null;
            }
            object[] args = new object[] { appId, redirectUrl, responseType, scope, state };
            return string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type={2}&scope={3}&state={4}#wechat_redirect", args);
        }

        public string GetOpenIdUrl(string appId, string secret, string code, string grantType = "authorization_code")
        {
            object[] args = new object[] { appId, secret, code, grantType };
            // https://api.weixin.qq.com/sns/jscode2session?appid=APPID&secret=SECRET&js_code=JSCODE&grant_type=authorization_code
            string requestUri = string.Format("https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code", args);
            return requestUri;
        }
        public string GetUserListUrl(string ACCESS_TOKEN, string nextopenid)
        {
            string requestUri = $"https://api.weixin.qq.com/cgi-bin/user/get?access_token={ACCESS_TOKEN}&next_openid={nextopenid}";
            return requestUri;
        }
        /// <summary>
        /// 获取公众号token
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public string GettokenUrl(string appid, string secret)
        {
            return $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={appid}&secret={secret}";
        }
       
        /// <summary>
        /// 获取openid
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="secret"></param>
        /// <param name="code"></param>
        /// <param name="grantType"></param>
        /// <returns></returns>
        public async Task<WXInfoDto> GetOpenid(string appId, string secret, string code, string grantType = "authorization_code")
        {
            string requestUri = GetOpenIdUrl(appId, secret, code, grantType);
            var responseStr = _httpClient.GetAsync(requestUri).Result.Content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseStr);
            string stropenid = string.Empty;
            string strunionid = string.Empty;
            if (!obj.TryGetValue("openid", out stropenid))
            {
                //Log.Info($"获取openid失败appId={appId}，secret={secret}，code={code}");
            }
            if (!obj.TryGetValue("unionid", out strunionid))
            {                
                //Log.Info($"获取openid失败appId={appId}，secret={secret}，code={code}");
            }
            return await Task.Run(() => new WXInfoDto() { openid = stropenid, unionid = strunionid });
        }
    }
}
