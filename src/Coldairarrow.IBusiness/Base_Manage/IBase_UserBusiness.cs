﻿using Coldairarrow.Entity;
using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Base_Manage
{
    public interface IBase_UserBusiness
    {
        Task<PageResult<Base_UserDTO>> GetDataListAsync(PageInput<Base_UsersInputDTO> input);
        Task<List<SelectOption>> GetOptionListAsync(OptionListInputDTO input);
        Task<Base_UserDTO> GetTheDataAsync(string id);
        Task AddDataAsync(UserEditInputDTO input);
        Task UpdateDataAsync(UserEditInputDTO input);
        Task DeleteDataAsync(List<string> ids);
        Task AddAssocDataAsync(AssocEditInputDTO input);
        Task UpdateAssocDataAsync(AssocEditInputDTO input);
    }

    [Map(typeof(Base_User))]
    public class UserEditInputDTO : Base_User
    {
        public string newPwd { get; set; }
        public List<string> RoleIdList { get; set; }
    }

    [Map(typeof(Base_User))]
    public class AssocEditInputDTO : Base_User
    {
        public string newPwd { get; set; }
        public List<string> AssocIdList { get; set; }
    }

    public class Base_UsersInputDTO
    {
        public bool all { get; set; }
        public string userId { get; set; }
        public string keyword { get; set; }
    }
}