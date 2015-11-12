namespace AuthorityManagement.Presentations.Attributes
{
    using System;

    using AuthorityManagement.Security;

    /// <summary>
    /// 收集系统模块.
    /// </summary>
    public class SystemModelAttribute : Attribute
    {
        /// <summary>
        /// 模块名称.
        /// </summary>
        private string name;

        /// <summary>
        /// 分组名称.
        /// </summary>
        private string groupName;

        /// <summary>
        /// 只读模块名称.
        /// </summary>
        public string Name {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// 分组名称.
        /// </summary>
        public string GroupName {
            get
            {
                return this.groupName;
            }

            set
            {
                // 如果是通过构造函数初始化的名称，则其他设置均无效
                if (string.IsNullOrEmpty(this.groupName))
                {
                    this.groupName = value;    
                }
            }
        }

        /// <summary>
        /// 模块的权限.
        /// </summary>
        private PermissionValue permissionValue;

        /// <summary>
        /// 模块的权限.
        /// </summary>
        public PermissionValue PermissionValue {
            get
            {
                return this.permissionValue;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemModelAttribute"/> class.
        /// </summary>
        /// <param name="name">
        /// 模块名称.
        /// </param>
        /// <param name="permissionValue">
        /// 模块权限值.
        /// </param>
        /// <param name="groupName">
        /// 分组名称.
        /// </param>
        public SystemModelAttribute(string name, PermissionValue permissionValue = PermissionValue.All, string groupName = null)
        {
            this.name = name;
            this.groupName = groupName;
            this.permissionValue = permissionValue;
        }
    }
}