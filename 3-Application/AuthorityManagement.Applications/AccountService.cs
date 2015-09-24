using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityManagement.Applications
{
    using Apworks.Specifications;

    using AuthorityManagement.Core.Domains;
    using AuthorityManagement.Core.Repositories;
    using AuthorityManagement.Presentations;

    /// <summary>
    /// The account service.
    /// </summary>
    public class AccountService:IAccountService
    {
        /// <summary>
        /// The user repository.
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="userRepository">
        /// The user repository.
        /// </param>
        public AccountService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// The login.
        /// </summary>
        /// <param name="loginInput">
        /// The login input.
        /// </param>
        /// <returns>
        /// The <see cref="LoginOutPut"/>.
        /// </returns>
        public LoginOutPut Login(LoginInput loginInput)
        {
            var user =
                this.userRepository.Find(
                    Specification<User>.Eval(u => string.Compare(u.UserName, loginInput.UserName,StringComparison.OrdinalIgnoreCase) == 0));

            if (user == null)
            {
                return new LoginOutPut()
                {
                    IsError = true,
                    ErrorMessage = "用户不存在"
                };
            }

            if (String.CompareOrdinal(user.Password, loginInput.Password) != 0)
            {
                return new LoginOutPut()
                           {
                               IsError = true,
                               ErrorMessage = "密码错误"
                           };
            }

            return new LoginOutPut()
                       {
                           LoginUserId = user.ID
                       };
        }
    }
}
