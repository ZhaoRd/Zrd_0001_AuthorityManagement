namespace AuthorityManagement.Presentations.RoleServices.Dtos
{
    /// <summary>
    /// 角色DTO.
    /// </summary>
    public class RoleDto : EntityDto
    {
        /// <summary>
        /// 角色名称.
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 是否为默认.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// 角色描述.
        /// </summary>
        public string Description { get; set; }
    }
}