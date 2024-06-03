using Coldairarrow.Entity;
using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Base_Manage
{
    public interface IBase_MenuBusiness
    {
        Task<List<Base_Menu>> GetDataListAsync(Base_MenusInputDTO input);
        Task<List<Base_MenuDTO>> GetTreeDataListAsync(Base_MenusInputDTO input);
        Task<Base_Menu> GetTheDataAsync(string id);
        Task AddDataAsync(MenuEditInputDTO input);
        Task UpdateDataAsync(MenuEditInputDTO input);
        Task DeleteDataAsync(List<string> ids);
    }

    [Map(typeof(Base_Menu))]
    public class MenuEditInputDTO : Base_Menu
    {
        public List<Base_Menu> permissionList { get; set; } = new List<Base_Menu>();
    }

    public class Base_MenusInputDTO
    {
        public string[] ActionIds { get; set; }
        public string parentId { get; set; }
        public ActionType[] types { get; set; }
        public bool selectable { get; set; }
        public bool checkEmptyChildren { get; set; }
    }

    public class Base_MenuDTO : TreeModel
    {
        public ActionType Type { get; set; }
        public String Url { get; set; }
        public string path { get => Url; }
        public bool NeedAction { get; set; }
        public string TypeText { get => ((ActionType)Type).ToString(); }
        public string NeedActionText { get => NeedAction ? "是" : "否"; }
        public object children { get => Children; }
        public string title { get => Text; }
        public string value { get => Id; }
        public string key { get => Id; }
        public bool selectable { get; set; }
        [JsonIgnore]
        public string Icon { get; set; }
        public string icon { get => Icon; }
        public int Sort { get; set; }
        public List<string> PermissionValues { get; set; }
    }
}