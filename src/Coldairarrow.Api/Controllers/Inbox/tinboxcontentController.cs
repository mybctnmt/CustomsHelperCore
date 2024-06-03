using Coldairarrow.Business.Inbox;
using Coldairarrow.Entity.DTO;
using Coldairarrow.Entity.Inbox;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Inbox
{
    [Route("/Inbox/[controller]/[action]")]
    public class tinboxcontentController : BaseApiController
    {
        #region DI

        public tinboxcontentController(ItinboxcontentBusiness tinboxcontentBus)
        {
            _tinboxcontentBus = tinboxcontentBus;
        }

        ItinboxcontentBusiness _tinboxcontentBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<tinboxcontent>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _tinboxcontentBus.GetDataListAsync(input);
        }
        [HttpGet]
        public async Task<tinboxcontent> GetOneData(string email)
        {
            return await _tinboxcontentBus.GetOneData(email);
        }
        [HttpGet]
        public async Task<tinboxcontent> GetOneDataEmailId(string emailId, DateTime sendTime)
        {
            return await _tinboxcontentBus.GetOneDataEmailId(emailId, sendTime);
        }
        [HttpPost]
        public async Task<tinboxcontent> GetTheData(IdInputDTO input)
        {
            return await _tinboxcontentBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task<string> SaveData(tinboxcontent data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

             return   await _tinboxcontentBus.AddDataAsync(data);
            }
            else
            {
             return   await _tinboxcontentBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _tinboxcontentBus.DeleteDataAsync(ids);
        }
        
        [HttpPost]
        public async Task AddInboxInfo(List<tinboxinfo> data)
        {
            if (data.IsNullOrEmpty())
            {
                throw new BusException("信息不能为空！");
            }
            foreach (var item in data)
            {
                tinboxcontent tinboxcontent = item.tinboxcontent;
                List<tinboxattachment> tinboxattachments = item.tinboxattachments;
                InitEntity(tinboxcontent);
                foreach (var tinboxattachment in tinboxattachments)
                {
                    InitEntity(tinboxattachment);
                    tinboxattachment.InboxId = tinboxcontent.Id;
                }
            }
            await _tinboxcontentBus.AddInboxInfoAsync(data);
        }
        #endregion
    }
}