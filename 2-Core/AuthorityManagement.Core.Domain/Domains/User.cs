// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="Skymate">
//   copyright @ 2015 skymate.
// </copyright>
// <summary>
//   Defines the User type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AuthorityManagement.Core.Domains
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Apworks;

    using AuthorityManagement.Security;

    using Skymate.Entities;

    /// <summary>
    /// 用户.
    /// </summary>
    public class User : SkymateAggregateRoot, IPassivable
    {
        /// <summary>
        /// 用户名.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 是否激活.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 用户所在角色.
        /// </summary>
        public virtual ICollection<UserInRole> UserInRoles { get; set; }

        /// <summary>
        /// 激活账户.
        /// </summary>
        public void Active()
        {
            this.IsActive = true;
        }

        /// <summary>
        /// 禁用账户.
        /// </summary>
        public void DisActive()
        {
            this.IsActive = false;
        }

    }

    /// <summary>
    /// 组织
    /// </summary>
    public class Group : SkymateAggregateRoot
    {
        /// <summary>
        /// 组织名称.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 组织描述.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 上一级组织.
        /// </summary>
        public virtual Group Parent { get; set; }
    }

    /// <summary>
    /// 用户所在组织.
    /// </summary>
    public class UserInGroup : IAggregateRoot
    {
        /// <summary>
        /// 主键.
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// 用户.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// 组织.
        /// </summary>
        public virtual Group Group { get; set; }
    }

    /// <summary>
    /// 角色.
    /// </summary>
    public class Role : SkymateAggregateRoot
    {
        /// <summary>
        /// 角色名称.
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 是否默认.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// 角色描述.
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// 用户所在角色.
    /// </summary>
    public class UserInRole : IAggregateRoot
    {
        /// <summary>
        /// 主键.
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// 用户.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// 角色.
        /// </summary>
        public virtual Role Role { get; set; }
    }

    /// <summary>
    /// 组织所在角色.
    /// </summary>
    public class GroupInRole : IAggregateRoot
    {
        /// <summary>
        /// 主键.
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// 组织.
        /// </summary>
        public virtual Group Group { get; set; }

        /// <summary>
        /// 角色.
        /// </summary>
        public virtual Role Role { get; set; }
    }

    /// <summary>
    /// 系统功能.
    /// </summary>
    public class Function : IAggregateRoot
    {
        /// <summary>
        /// 主键.
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// 模块名称.
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// 功能名称.
        /// </summary>
        public string FunctionName { get; set; }

        /// <summary>
        /// 描述.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Area名称.
        /// </summary>
        public string AreasName { get; set; }

        /// <summary>
        /// Controller名称.
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// Action名称.
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// 功能类型.暂未启用
        /// </summary>
        public FunctionType FunctionType { get; set; }

        /// <summary>
        /// 功能的权限值.
        /// </summary>
        public PermissionValue PermissionValue { get; set; }
    }

    /// <summary>
    /// 功能所在角色.
    /// </summary>
    public class FunctionInRole : IAggregateRoot
    {
        /// <summary>
        /// 主键.
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// 角色.
        /// </summary>
        public virtual Role Role { get; set; }

        /// <summary>
        /// 功能.
        /// </summary>
        public virtual Function Function { get; set; }

        /// <summary>
        /// 功能所在角色的权限值  .
        /// </summary>
        public PermissionValue PermissionValue { get; set; }
    }
}
