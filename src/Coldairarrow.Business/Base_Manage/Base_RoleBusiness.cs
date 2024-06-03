using AutoMapper;
using AutoMapper.QueryableExtensions;
using Coldairarrow.Entity;
using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Entity.Basic;
using Coldairarrow.Util;
using Dynamitey.DynamicObjects;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Base_Manage
{
    public class Base_RoleBusiness : BaseBusiness<Base_Role>, IBase_RoleBusiness, ITransientDependency
    {
        private readonly IDatabase _redis;
        readonly IMapper _mapper;
        public Base_RoleBusiness(IDbAccessor db, IMapper mapper, IConnectionMultiplexer redis)
            : base(db)
        {
            _mapper = mapper;
            _redis = redis.GetDatabase();
        }

        #region 外部接口

        public async Task<PageResult<Base_RoleInfoDTO>> GetDataListAsync(PageInput<RolesInputDTO> input)
        {
            //string cacheKey = "DataList-Base_Role";

            //string cachedDataJson = await _redis.StringGetAsync(cacheKey);
            //if (!string.IsNullOrEmpty(cachedDataJson))
            //{
            //    var cachedData = JsonConvert.DeserializeObject<PageResult<Base_RoleInfoDTO>>(cachedDataJson);
            //    if (cachedData != null)
            //    {
            //        return cachedData;
            //    }
            //}
            var where = LinqHelper.True<Base_Role>();
            var search = input.Search;
            if (!search.roleId.IsNullOrEmpty())
                where = where.And(x => x.Id == search.roleId);
            if (!search.roleName.IsNullOrEmpty())
                where = where.And(x => x.RoleName.Contains(search.roleName));

            var page = await GetIQueryable()
                .Where(where)
                .ProjectTo<Base_RoleInfoDTO>(_mapper.ConfigurationProvider)
                .GetPageResultAsync(input);

            await SetProperty(page.Data);
            //string dataJson = JsonConvert.SerializeObject(page);
            //await _redis.StringSetAsync(cacheKey, dataJson);
            return page;

            async Task SetProperty(List<Base_RoleInfoDTO> _list)
            {
                var allActionIds = await Db.GetIQueryable<Base_Action>().Select(x => x.Id).ToListAsync();
                var allMenuIds = await Db.GetIQueryable<Base_Menu>().Select(x => x.Id).ToListAsync();

                var ids = _list.Select(x => x.Id).ToList();

                var roleActions = await Db.GetIQueryable<Base_RoleAction>()
                    .Where(x => ids.Contains(x.RoleId))
                    .ToListAsync();

                var menuActions = await Db.GetIQueryable<Base_RoleMenu>()
                    .Where(x => ids.Contains(x.RoleId))
                    .ToListAsync();

                _list.ForEach(aData =>
                {
                    if (aData.RoleName == RoleTypes.超级管理员.ToString())
                    {
                        aData.Actions = allActionIds;
                        aData.Menus = allMenuIds;
                    }
                    else
                    {
                        aData.Actions = roleActions.Where(x => x.RoleId == aData.Id).Select(x => x.ActionId).ToList();
                        aData.Menus = menuActions.Where(x => x.RoleId == aData.Id).Select(x => x.MenuId).ToList();
                    }
                });
            }
        }

        public async Task<Base_RoleInfoDTO> GetTheDataAsync(string id)
        {
            return (await GetDataListAsync(new PageInput<RolesInputDTO> { Search = new RolesInputDTO { roleId = id } })).Data.FirstOrDefault();
        }

        [DataAddLog(UserLogType.系统角色管理, "RoleName", "角色")]
        [DataRepeatValidate(new string[] { "RoleName" }, new string[] { "角色名" })]
        public async Task AddDataAsync(Base_RoleInfoDTO input)
        {
            await InsertAsync(_mapper.Map<Base_Role>(input));
            await SetRoleActionAsync(input.Id, input.Actions);
        }

        [DataEditLog(UserLogType.系统角色管理, "RoleName", "角色")]
        [DataRepeatValidate(new string[] { "RoleName" }, new string[] { "角色名" })]
        [Transactional]
        public async Task UpdateDataAsync(Base_RoleInfoDTO input)
        {
            await UpdateAsync(_mapper.Map<Base_Role>(input));
            await SetRoleActionAsync(input.Id, input.Actions);
        }

        [DataDeleteLog(UserLogType.系统角色管理, "RoleName", "角色")]
        [Transactional]
        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
            await Db.DeleteAsync<Base_RoleAction>(x => ids.Contains(x.RoleId));
            await Db.DeleteAsync<Base_RoleMenu>(x => ids.Contains(x.RoleId));
        }

        [DataAddLog(UserLogType.系统角色管理, "RoleName", "角色")]
        [DataRepeatValidate(new string[] { "RoleName" }, new string[] { "角色名" })]
        public async Task AddMenuDataAsync(Base_RoleInfoDTO input)
        {
            await InsertAsync(_mapper.Map<Base_Role>(input));
            await SetRoleMenuAsync(input.Id, input.Menus);
        }

        [DataEditLog(UserLogType.系统角色管理, "RoleName", "角色")]
        [DataRepeatValidate(new string[] { "RoleName" }, new string[] { "角色名" })]
        public async Task UpdateMenuDataAsync(Base_RoleInfoDTO input)
        {
            await UpdateAsync(_mapper.Map<Base_Role>(input));
            await SetRoleMenuAsync(input.Id, input.Menus);
        }

        #endregion

        #region 私有成员

        private async Task SetRoleActionAsync(string roleId, List<string> actions)
        {
            var roleActions = (actions ?? new List<string>())
                .Select(x => new Base_RoleAction
                {
                    Id = IdHelper.GetId(),
                    ActionId = x,
                    CreateTime = DateTime.Now,
                    RoleId = roleId
                }).ToList();
            await Db.DeleteAsync<Base_RoleAction>(x => x.RoleId == roleId);
            await Db.InsertAsync(roleActions);
        }

        private async Task SetRoleMenuAsync(string roleId, List<string> actions)
        {
            var roleActions = (actions ?? new List<string>())
                .Select(x => new Base_RoleMenu
                {
                    Id = IdHelper.GetId(),
                    MenuId = x,
                    CreateTime = DateTime.Now,
                    RoleId = roleId
                }).ToList();
            await Db.DeleteAsync<Base_RoleMenu>(x => x.RoleId == roleId);
            await Db.InsertAsync(roleActions);
        }

        #endregion

        #region 数据模型

        #endregion
    }
}