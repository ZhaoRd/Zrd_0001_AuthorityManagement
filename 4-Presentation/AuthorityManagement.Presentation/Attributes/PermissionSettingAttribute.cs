namespace AuthorityManagement.Presentation.Attributes
{
    using System;

    using AuthorityManagement.Security;

    /// <summary>
    /// 权限信息设置，以便信息收集.
    /// </summary>
    public class PermissionSettingAttribute : Attribute
    {
        /// <summary>
        /// 具体权限.
        /// </summary>
        private readonly PermissionValue permissionValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionSettingAttribute"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public PermissionSettingAttribute(PermissionValue value)
        {
            this.permissionValue = value;
        }

        /// <summary>
        /// Gets the permission value.
        /// </summary>
        public PermissionValue PermissionValue
        {
            get
            {
                return this.permissionValue;
            }
        }
    }
}