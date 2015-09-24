// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PermissionValue.cs" company="skymate">
//   copyright @ 2015 skymate.
// </copyright>
// <summary>
//   定义权限.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AuthorityManagement.Security
{
    using System;

    using Skymate.Attributes;

    /// <summary>
    /// 定义权限.
    /// </summary>
    [Flags]
    public enum PermissionValue
    {
        /// <summary>
        /// The create.
        /// </summary>
        [EnumDescription("创建")]
        Create = 1, 

        /// <summary>
        /// The edit.
        /// </summary>
        [EnumDescription("编辑")]
        Edit = 2, 

        /// <summary>
        /// The delete.
        /// </summary>
        [EnumDescription("删除")]
        Delete = 4, 

        /// <summary>
        /// The detail.
        /// </summary>
        [EnumDescription("详细")]
        Detail = 8, 

        /// <summary>
        /// The audit.
        /// </summary>
        [EnumDescription("审核")]
        Audit = 16, 

        /// <summary>
        /// The lookup.
        /// </summary>
        [EnumDescription("查看")]
        Lookup = 32, 

        /// <summary>
        /// The print.
        /// </summary>
        [EnumDescription("打印")]
        Print = 64, 

        /// <summary>
        /// The download.
        /// </summary>
        [EnumDescription("下载")]
        Download = 128,

        /// <summary>
        /// The all.
        /// </summary>
        [EnumDescription("全部")]
        All = Create | Edit | Delete | Detail | Audit | Lookup | Print | Download,

        /// <summary>
        /// The none.
        /// </summary>
        [EnumDescription("无")]
        None = 0
    }
}
