using Coldairarrow.Business.Fieldwork;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Entity.Fieldwork;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Fieldwork
{
    [Route("/Fieldwork/[controller]/[action]")]
    public class ttaskheadController : BaseApiController
    {
        #region DI

        public ttaskheadController(IttaskheadBusiness ttaskheadBus)
        {
            _ttaskheadBus = ttaskheadBus;
        }

        IttaskheadBusiness _ttaskheadBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<ttaskhead>> GetDataList(TaskHeadInputDto input)
        {
            return await _ttaskheadBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<ttaskhead> GetTheData(IdInputDTO input)
        {
            return await _ttaskheadBus.GetTheDataAsync(input.id);
        }

        [HttpGet]
        public async Task<TaskInfoDto> GetTaskInfo(string id)
        {
            return await _ttaskheadBus.GetTaskInfo(id);
        }
        #endregion

        #region 提交
        [HttpPost]
        public async Task SaveTaskInfo(TaskInfoDto taskInfo)
        {
            if (taskInfo.IsNullOrEmpty() 
                || taskInfo.ttaskhead.IsNullOrEmpty() 
                || taskInfo.ttaskhead.Id.IsNullOrEmpty())
            {
                throw new BusException("请先创建任务！");
            }
            if (taskInfo.ttaskhead.IsCompleted.HasValue 
                && taskInfo.ttaskhead.IsCompleted.Value)
            {
                throw new BusException("任务已完成！");
            }
            InitEntity(taskInfo.ttaskfeedback);
            foreach (var ttaskattachment in taskInfo.ttaskattachments)
            {
                InitEntity(ttaskattachment);
            }
            foreach (var ttaskcost in taskInfo.ttaskcosts)
            {
                InitEntity(ttaskcost);
            }
            await _ttaskheadBus.SaveTaskInfo(taskInfo);
        }

        [HttpPost]
        public async Task SaveData(ttaskhead data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _ttaskheadBus.AddDataAsync(data);
            }
            else
            {
                await _ttaskheadBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _ttaskheadBus.DeleteDataAsync(ids);
        }

        [HttpPost]
        public async Task AcceptTask(string id)
        {
            await _ttaskheadBus.AcceptTaskAsync(id);
        }
        #endregion
    }
}