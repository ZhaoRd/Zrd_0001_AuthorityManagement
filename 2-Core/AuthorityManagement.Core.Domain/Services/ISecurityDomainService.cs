// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISecurityDomainService.cs" company="Skymate">
//   copyright (C) 2015 skymate. All Right
// </copyright>
// <summary>
//   The SecurityDomainService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AuthorityManagement.Core.Services
{
    using System;

    using AuthorityManagement.Security;

    /// <summary>
    /// The SecurityDomainService interface.
    /// </summary>
    public interface ISecurityDomainService
    {
        /// <summary>
        /// 为角色功能添加权限.
        /// </summary>
        /// <param name="functionId">
        /// 功能ID.
        /// </param>
        /// <param name="roleId">
        /// 角色ID.
        /// </param>
        /// <param name="toAddPermission">
        /// 需要添加的权限.
        /// </param>
        void AddAuthority(Guid functionId, Guid roleId, PermissionValue toAddPermission);

        /// <summary>
        /// 为角色功能删除权限.
        /// </summary>
        /// <param name="functionId">
        /// 功能ID.
        /// </param>
        /// <param name="roleId">
        /// 角色ID.
        /// </param>
        /// <param name="toRemovePermission">
        /// 需要移除的权限.
        /// </param>
        void DeleteAuthority(Guid functionId, Guid roleId, PermissionValue toRemovePermission);

        /// <summary>
        /// 验证角色对功能的权限.
        /// </summary>
        /// <param name="functionId">
        /// 功能ID.
        /// </param>
        /// <param name="roleId">
        /// 角色ID.
        /// </param>
        /// <param name="toVerification">
        /// 需要验证的权限值.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>bool</cref>
        ///     </see>
        ///     .
        /// </returns>
        bool VerifyPermission(Guid functionId, Guid roleId, PermissionValue toVerification);

        /// <summary>
        /// 两个权限值的验证.
        /// </summary>
        /// <param name="toVerification">
        /// 需要验证的权限值.
        /// </param>
        /// <param name="functionInRole">
        /// 以及存在的权限值.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool VerifyPermission(PermissionValue toVerification, PermissionValue functionInRole);
    }
}