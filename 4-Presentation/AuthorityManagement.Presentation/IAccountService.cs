using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityManagement.Presentations
{
    /// <summary>
    /// The AccountService interface.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// 登录信息.
        /// </summary>
        /// <param name="loginInput">
        /// 登录输入的内容.
        /// </param>
        /// <returns>
        /// The <see cref="LoginOutPut"/>.
        /// </returns>
        LoginOutPut Login(LoginInput loginInput);
    }

    /// <summary>
    /// 登录结果返回的内容.
    /// </summary>
    public class LoginOutPut
    {
        /// <summary>
        /// 登录成功记录的用户ID.
        /// </summary>
        public Guid LoginUserId{ get; set; }

        /// <summary>
        /// 表示是否登录失败.
        /// </summary>
        public bool IsError{ get; set; }

        /// <summary>
        /// 登录失败信息.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
