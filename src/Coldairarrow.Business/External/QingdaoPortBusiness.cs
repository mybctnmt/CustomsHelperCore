using Coldairarrow.Business.Dec;
using Coldairarrow.Business.Inbox;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Entity.External;
using Coldairarrow.Entity.Fieldwork;
using Coldairarrow.Entity.Inbox;
using Coldairarrow.Util;
using Coldairarrow.Util.Primitives;
using EFCore.Sharding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldairarrow.Business.External
{
    public class QingdaoPortBusiness : BaseBusiness<Arrival>, IQingdaoPortBusiness, ITransientDependency
    {
        ItemailorderBusiness _temailorderBus { get; set; }
        ItdecheadBusiness _tdecheadBus { get; set; }
        public QingdaoPortBusiness(IDbAccessor db, ItemailorderBusiness temailorderBus, ItdecheadBusiness tdecheadBus)
            : base(db)
        {
            _temailorderBus = temailorderBus;
            _tdecheadBus = tdecheadBus;
        }
        public async Task<QingdaoPortResult> UpdateArrivalAsync(Arrival arrival)
        {
            try
            {

                StringBuilder sb = new StringBuilder();
                List<Data> datas = arrival.data;
                if (datas.Count > 0)
                {
                    List<tdeccontainer> tdeccontainers = new List<tdeccontainer>();
                    int cntrCount = datas.Count;
                    string billNo = "";
                    string trafName = "";
                    string cusVoyageNo = "";
                    string customMaster = "";
                    decimal grossWet = 0;
                    int packNo = 0;
                    string HZMS = "";
                    string HZSJ = "";

                    foreach (Data data in datas)
                    {
                        packNo = !string.IsNullOrEmpty(data.ZJS) ? Convert.ToInt32(data.ZJS) : 0;
                        grossWet = !string.IsNullOrEmpty(data.MZ) ? Convert.ToInt32(data.MZ) : 0;
                        customMaster = data.SBDHGDM;
                        cusVoyageNo = data.CKHC;
                        trafName = data.YWCM;
                        billNo = data.TDH;
                        tdeccontainers.Add(new tdeccontainer
                        {
                            ContainerId = data.XH,
                            ContainerMd = data.CCXX
                        });
                        HZMS += data.HZMS;
                        HZSJ = data.HZSJ;
                    }

                    tdechead tdechead = Db.GetIQueryable<tdechead>().Where(t => t.BillNo == billNo).FirstOrDefault();
                    List<tbasenorms> tbasenorms = Db.GetIQueryable<tbasenorms>().ToList();
                    if (tdechead != null)
                    {
                        tdecinfo decData = await _tdecheadBus.GetDecInfo(tdechead.OrderNo);
                        sb.Append("舱单运抵:");
                        if (packNo != decData.tdechead.PackNo)//比对件数
                        {
                            sb.Append("件数不一致");
                        }
                        if (grossWet != decData.tdechead.GrossWet)//比对重量
                        {
                            sb.Append("重量不一致");
                        }
                        if (customMaster != decData.tdechead.CustomMaster)//比对关区
                        {
                            sb.Append("关区不一致");
                        }
                        if (cusVoyageNo != decData.tdechead.CusVoyageNo)//比对航次
                        {
                            sb.Append("航次不一致");
                        }
                        if (trafName != decData.tdechead.TrafName)//比对运输工具名称
                        {
                            sb.Append("船名不一致");
                        }
                        if (decData.tdeccontainers.Count != cntrCount)
                        {
                            sb.Append("箱数不一致");
                        }
                        else
                        {
                            foreach (tdeccontainer deccontainer in decData.tdeccontainers)
                            {
                                tdeccontainer cntr = tdeccontainers.FirstOrDefault(a => a.ContainerId == deccontainer.ContainerId);
                                if (cntr == null)
                                {
                                    sb.Append($"{deccontainer.ContainerId}未找到箱子");
                                    continue;
                                }
                                if ((cntr.ContainerMd.StartsWith("4") ? "L" : "S") != tbasenorms.FirstOrDefault(a => a.codeValue == deccontainer.ContainerMd).cusCode)
                                {
                                    sb.Append($"{deccontainer.ContainerId}箱型不一致");
                                }
                            }
                        }

                        await _temailorderBus.UpdateManifestArrivalAsync(new temailorder
                        {
                            Id = decData.temailorder.Id,
                            IsManifest = HZMS.Contains("接受申报") ? "1" : "",
                            IsArrival = HZMS.Contains("接受申报_正常理货") ? "1" : "",
                            HGManifestTime = !string.IsNullOrEmpty(HZSJ) ? Convert.ToDateTime(HZSJ) : (DateTime?)null,
                            HGArrivalTime = !string.IsNullOrEmpty(HZSJ) ? Convert.ToDateTime(HZSJ) : (DateTime?)null,
                            MAInterfaceResult = HZMS,
                            MACheckResult = sb.ToString()
                        });
                    }
                }
                return new QingdaoPortResult
                {
                    success = true,
                    message = "操作成功"
                };
            }
            catch (Exception ex)
            {
                return new QingdaoPortResult
                {
                    success = false,
                    message = ex.Message
                };
            }
        }
    }
}