using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityManagement.Presentations.UserServices.Dtos
{
    /// <summary>
    /// 角色DTO.
    /// </summary>
    public class UserDto : EntityDto
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

    }

}
