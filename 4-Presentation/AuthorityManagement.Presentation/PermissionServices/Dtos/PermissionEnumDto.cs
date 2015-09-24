namespace AuthorityManagement.Presentations.PermissionServices.Dtos
{
    using System;

    using AuthorityManagement.Presentation.Dtos;

    /// <summary>
    /// 权限枚举的DTO.
    /// </summary>
    public class PermissionEnumDto : IOutputDto
    {
        /// <summary>
        /// 权限值.
        /// </summary>
        public Enum PermissionValue { get; set; }

        /// <summary>
        /// 角色是否拥有权限.
        /// </summary>
        public bool RoleHas { get; set; }

        /// <summary>
        /// 模块是否拥有权限.
        /// </summary>
        public bool FunctionHas { get; set; }
    }
}