using Coldairarrow.Entity.Dec;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Entity.Nems;
using Coldairarrow.IBusiness;
using Coldairarrow.Util;
using EFCore.Sharding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Dec
{
    public class SWHelperBusiness : BaseBusiness<tdechead>, ISWHelperBusiness, ITransientDependency
    {
        public SWHelperBusiness(IDbAccessor db) : base(db)
        {
        }

        public Task<DecDataDto> GetDecData(string orderNo)
        {

            return Task.Run(() => new DecDataDto
            {
                dechead = Db.GetIQueryable<tdechead>().FirstOrDefault(a => a.OrderNo == orderNo),
                declists = Db.GetIQueryable<tdeclist>().Where(a => a.OrderNo == orderNo).ToList(),
                deccontainers = Db.GetIQueryable<tdeccontainer>().Where(a => a.OrderNo == orderNo).ToList(),
                deccoplimits = Db.GetIQueryable<tdeccoplimit>().Where(a => a.OrderNo == orderNo).ToList(),
                deccoppromises = Db.GetIQueryable<tdeccoppromise>().Where(a => a.OrderNo == orderNo).ToList(),
                decfreetxt = Db.GetIQueryable<tdecfreetxt>().FirstOrDefault(a => a.OrderNo == orderNo),
                decgoodslimits = Db.GetIQueryable<tdecgoodslimit>().Where(a => a.OrderNo == orderNo).ToList(),
                decgoodslimitvins = Db.GetIQueryable<tdecgoodslimitvin>().Where(a => a.OrderNo == orderNo).ToList(),
                declicensedocuss = Db.GetIQueryable<tdeclicensedocus>().Where(a => a.OrderNo == orderNo).ToList(),
                decmarklobs = Db.GetIQueryable<tdecmarklob>().Where(a => a.OrderNo == orderNo).ToList(),
                decotherpacks = Db.GetIQueryable<tdecotherpack>().Where(a => a.OrderNo == orderNo).ToList(),
                decrequestcerts = Db.GetIQueryable<tdecrequestcert>().Where(a => a.OrderNo == orderNo).ToList(),
                decrisks = Db.GetIQueryable<tdecrisk>().Where(a => a.OrderNo == orderNo).ToList(),
                decroyaltyfees = Db.GetIQueryable<tdecroyaltyfee>().Where(a => a.OrderNo == orderNo).ToList(),
                decsign = Db.GetIQueryable<tdecsign>().FirstOrDefault(a => a.OrderNo == orderNo),
                decusers = Db.GetIQueryable<tdecuser>().Where(a => a.OrderNo == orderNo).ToList(),
                ecorelations = Db.GetIQueryable<tecorelation>().Where(a => a.OrderNo == orderNo).ToList(),
                edocrealations = Db.GetIQueryable<tedocrealation>().Where(a => a.OrderNo == orderNo).ToList(),
            });
        }

        public Task<NemsDataDto> GetNemsData(string orderNo)
        {
            return Task.Run(() => new NemsDataDto
            {
                invthead = Db.GetIQueryable<tinvthead>().FirstOrDefault(a => a.OrderNo == orderNo),
                invtlists = Db.GetIQueryable<tinvtlist>().Where(a => a.OrderNo == orderNo).ToList(),
                importinfo = Db.GetIQueryable<timportinfo>().FirstOrDefault(a => a.OrderNo == orderNo),
                invtsign = Db.GetIQueryable<tinvtsign>().FirstOrDefault(a => a.OrderNo == orderNo),
                nemsacmprlmessages = Db.GetIQueryable<tnemsacmprlmessage>().Where(a => a.OrderNo == orderNo).ToList()
            });
        }
        [Transactional]
        public async Task<bool> InsertNemsData(NemsDataDto nemsData)
        {
            await Db.InsertAsync(nemsData.invthead);
            await Db.InsertAsync(nemsData.invtsign);
            await Db.InsertAsync(nemsData.importinfo);
            await Db.InsertAsync(nemsData.nemsacmprlmessages);
            await Db.InsertAsync(nemsData.invtlists);
            return true;
        }
        [Transactional]
        public async Task<bool> UpdateNemsData(NemsDataDto nemsData)
        {
            await Db.UpdateAsync(nemsData.invthead);
            await Db.DeleteAsync<tinvtsign>(t => t.OrderNo == nemsData.invthead.OrderNo);
            await Db.DeleteAsync<timportinfo>(t => t.OrderNo == nemsData.invthead.OrderNo);
            await Db.DeleteAsync<tnemsacmprlmessage>(t => t.OrderNo == nemsData.invthead.OrderNo);
            await Db.DeleteAsync<tinvtlist>(t => t.OrderNo == nemsData.invthead.OrderNo);
            await Db.InsertAsync(nemsData.invtsign);
            await Db.InsertAsync(nemsData.importinfo);
            await Db.InsertAsync(nemsData.nemsacmprlmessages);
            await Db.InsertAsync(nemsData.invtlists);
            return true;
        }
    }
}
