using Coldairarrow.Entity.Dec;
using Coldairarrow.Entity.IAQ;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.IBusiness.IAQ
{
    public interface IiaqinfoBusiness
    {
        Task SaveIaqInfoAsync(iaqinfo iaqinfo);
        Task<iaqinfo> GetIaqInfo(string Unumber);

    }

}
