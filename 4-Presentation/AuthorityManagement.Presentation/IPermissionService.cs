using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityManagement.Presentations
{
    using AuthorityManagement.Presentation.Dtos;
    using AuthorityManagement.Security;

    // 权限的接口
    public interface IPermissionService
    {
        /// <summary>
        /// The verify authority.
        /// 验证权限
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool VerifyAuthority(VerifyAuthorityInputDto verifyAuthorityInputDto);

    }

    /// <summary>
    /// 验证权限输入的DTO.
    /// </summary>
    public class VerifyAuthorityInputDto : IInputDto
    {
        /// <summary>
        /// 登录用户ID.
        /// </summary>
        public Guid LoginUserId { get; set; }

        /// <summary>
        /// 系统名称.
        /// </summary>
        public string SystemModelName { get; set; }

        /// <summary>
        /// 分组名称.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 权限值.
        /// </summary>
        public PermissionValue PermissionValue { get; set; }
    }
}
