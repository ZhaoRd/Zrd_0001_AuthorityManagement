namespace AuthorityManagement.Presentations.UserServices.Dtos
{
    using System;

    using AuthorityManagement.Presentation.Dtos;

    /// <summary>
    /// 编辑用户输入DTO.
    /// </summary>
    public class EditUserInputDto : UserDto,IInputDto
    {
        /// <summary>
        /// 选中的角色.
        /// </summary>
        public Guid[] RoleIds { get; set; }
    }
}