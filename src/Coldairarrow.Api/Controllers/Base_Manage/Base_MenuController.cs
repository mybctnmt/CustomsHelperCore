using Coldairarrow.Business.Base_Manage;
using Coldairarrow.Entity;
using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Base_Manage
{
    /// <summary>
    /// 系统权限
    /// </summary>
    /// <seealso cref="Coldairarrow.Api.BaseApiController" />
    [Route("/Base_Manage/[controller]/[action]")]
    [OpenApiTag("系统权限")]
    public class Base_MenuController : BaseApiController
    {
        #region DI

        public Base_MenuController(IBase_MenuBusiness actionBus)
        {
            _actionBus = actionBus;
        }

        IBase_MenuBusiness _actionBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<Base_Menu> GetTheData(IdInputDTO input)
        {
            return (await _actionBus.GetTheDataAsync(input.id)) ?? new Base_Menu();
        }

        [HttpPost]
        public async Task<List<Base_Menu>> GetPermissionList(Base_MenusInputDTO input)
        {
            input.types = new ActionType[] { Entity.ActionType.权限 };

            return await _actionBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<List<Base_Menu>> GetAllActionList()
        {
            return await _actionBus.GetDataListAsync(new Base_MenusInputDTO
            {
                types = new ActionType[] { ActionType.菜单, ActionType.页面, ActionType.权限 }
            });
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(MenuEditInputDTO input)
        {
            if (input.Id.IsNullOrEmpty())
            {
                InitEntity(input);

                await _actionBus.AddDataAsync(input);
            }
            else
            {
                await _actionBus.UpdateDataAsync(input);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _actionBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}