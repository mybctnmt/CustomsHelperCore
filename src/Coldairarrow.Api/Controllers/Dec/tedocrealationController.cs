using Coldairarrow.Business.Dec;
using Coldairarrow.Entity.Dec;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Dec
{
    [Route("/Dec/[controller]/[action]")]
    public class tedocrealationController : BaseApiController
    {
        #region DI

        public tedocrealationController(ItedocrealationBusiness tedocrealationBus)
        {
            _tedocrealationBus = tedocrealationBus;
        }

        ItedocrealationBusiness _tedocrealationBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tedocrealation>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tedocrealationBus.GetDataListAsync(input);
        }
        [HttpPost]
        public async Task<List<tedocrealation>> GetDataOrderList(List<string> order)
        {
            return await _tedocrealationBus.GetDataListOrderAsync(order);
        }

        [HttpPost]
        public async Task<tedocrealation> GetTheData(IdInputDTO input)
        {
            return await _tedocrealationBus.GetTheDataAsync(input.id);
        }
        

        [HttpPost]
        public async Task<List<tedocrealation>> GetDataByEdocIDs(List<string> docIds)
        {
            return await _tedocrealationBus.GetDataByEdocIDs(docIds);
        }

        #endregion

        #region 提交
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        [HttpPost]
        public async Task SaveData(tedocrealation data)
        {
            try
            {
                await _semaphore.WaitAsync(); // 等待直到可以进入
                if (data.Id.IsNullOrEmpty())
                {
                    InitEntity(data);
                    await _tedocrealationBus.AddDataAsync(data);
                }
                else
                {
                    await _tedocrealationBus.UpdateDataAsync(data);
                }
            }
            finally
            {
                _semaphore.Release(); // 确保释放信号量
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tedocrealationBus.DeleteDataAsync(ids);
        }

        [HttpPost]
        public async Task SaveDataByEdocCode(tedocrealation data)
        {
            InitEntity(data);
            await _tedocrealationBus.SaveDataByEdocCode(data);
        }
        #endregion
    }
}