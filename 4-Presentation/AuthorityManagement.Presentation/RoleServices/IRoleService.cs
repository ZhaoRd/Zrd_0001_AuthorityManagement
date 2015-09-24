namespace AuthorityManagement.Presentations.RoleServices
{
    using System;
    using System.Collections.Generic;

    using AuthorityManagement.Presentations.RoleServices.Dtos;

    /// <summary>
    /// The RoleService interface.
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// 添加角色.
        /// </summary>
        /// <param name="roleInput">
        /// 输入角色.
        /// </param>
        void Add(RoleInputDto roleInput);

        /// <summary>
        /// 更新角色.
        /// </summary>
        /// <param name="roleInput">
        /// 输入角色.
        /// </param>
        void Update(RoleInputDto roleInput);

        /// <summary>
        /// 删除角色.
        /// </summary>
        /// <param name="userid">
        /// 角色ID.
        /// </param>
        void Delete(Guid userid);

        /// <summary>
        /// 根据ID获取角色.
        /// </summary>
        /// <param name="roleid">
        /// 角色ID.
        /// </param>
        /// <returns>
        /// The <see cref="RoleInputDto"/>.
        /// </returns>
        RoleInputDto GetRoleById(Guid roleid);

        /// <summary>
        /// 获取所有角色.
        /// </summary>
        /// <param name="pageIndex">
        /// 页吗.
        /// </param>
        /// <param name="pageSize">
        /// 每页大小.
        /// </param>
        /// <param name="total">
        /// 总数.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     .
        /// </returns>
        IEnumerable<RoleListOutputDto> GetAllRoles(int pageIndex, int pageSize, out int total);

        /// <summary>
        /// 获取所有角色.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     .
        /// </returns>
        IEnumerable<RoleListOutputDto> GetAllRoles();
    }
}
