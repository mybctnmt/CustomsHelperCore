using System.Collections.Generic;

namespace Coldairarrow.Util
{
    /// <summary>
    /// 分页返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResult<T> : AjaxResult<List<T>>
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int Total { get; set; }
    }
    /// <summary>
    /// 分页返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResultOrder<T> : AjaxResult<List<T>>
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 未输单票数
        /// </summary>
        public int IsConfirmOrderCount { get; set; }
        /// <summary>
        /// 驳回票数
        /// </summary>
        public int IsRejectCount { get; set; }
        /// <summary>
        /// 有效输单票数
        /// </summary>
        public int IsEntryClerkCount { get; set; }
    }
}
