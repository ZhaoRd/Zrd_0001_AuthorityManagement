namespace AuthorityManagement.Presentations.PermissionServices.Dtos
{
    using System;

    using AuthorityManagement.Presentation.Dtos;
    using AuthorityManagement.Security;

    /// <summary>
    /// 权限输入DTO.
    /// </summary>
    public class PermissionInputDto : IInputDto
    {
        /// <summary>
        /// Gets or sets the role id.
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Gets or sets the function id.
        /// </summary>
        public Guid FunctionId { get; set; }

        /// <summary>
        /// Gets or sets the permission value.
        /// </summary>
        public PermissionValue PermissionValue { get; set; }

    }
}