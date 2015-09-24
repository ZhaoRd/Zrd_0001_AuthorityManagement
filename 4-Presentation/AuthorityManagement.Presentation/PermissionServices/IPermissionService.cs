namespace AuthorityManagement.Presentations.PermissionServices
{
    using System;
    using System.Collections.Generic;

    using AuthorityManagement.Presentations.PermissionServices.Dtos;

    /// <summary>
    /// The PermissionService interface.
    /// </summary>
    public interface IPermissionService
    {
        /// <summary>
        /// 获取角色的权限列表.
        /// </summary>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<PermissionOutputDto> GetPermissionList(Guid roleId);

        /// <summary>
        /// 授权.
        /// </summary>
        /// <param name="accreditInput">
        /// The accredit input.
        /// </param>
        void Accredit(AccreditInputDto accreditInput);

        /// <summary>
        /// 禁止.
        /// </summary>
        /// <param name="accreditInput">
        /// The accredit input.
        /// </param>
        void Forbid(AccreditInputDto accreditInput);
    }
}
