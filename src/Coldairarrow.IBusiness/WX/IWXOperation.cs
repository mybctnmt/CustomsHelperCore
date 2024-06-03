using Coldairarrow.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.IBusiness.WX
{
   public interface IWXOperation
    {
        Task<WXInfoDto> GetOpenid(string appId, string secret, string code, string grantType = "authorization_code");
    }
}
