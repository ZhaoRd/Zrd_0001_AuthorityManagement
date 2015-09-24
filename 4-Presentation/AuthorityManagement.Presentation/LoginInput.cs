namespace AuthorityManagement.Presentations
{
    /// <summary>
    /// 登录时需要输入的信息.
    /// </summary>
    public class LoginInput
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
        /// 记住登陆.
        /// </summary>
        public bool IsRemeber { get; set; }
    }
}