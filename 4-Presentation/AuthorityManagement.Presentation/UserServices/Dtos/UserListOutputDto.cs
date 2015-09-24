namespace AuthorityManagement.Presentations.UserServices.Dtos
{
    using AuthorityManagement.Presentation.Dtos;

    /// <summary>
    /// 用户列表输出DTO.
    /// </summary>
    public class UserListOutputDto : UserDto,
        IOutputDto
    {
        /// <summary>
        /// 角色名.
        /// </summary>
        public string[] RoleNames { get; set; }
    }
}
