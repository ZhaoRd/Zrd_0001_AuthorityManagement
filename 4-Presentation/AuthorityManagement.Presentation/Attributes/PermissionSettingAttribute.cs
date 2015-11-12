namespace AuthorityManagement.Presentation.Attributes
{
    using System;

    using AuthorityManagement.Security;

    /// <summary>
    /// Ȩ����Ϣ���ã��Ա���Ϣ�ռ�.
    /// </summary>
    public class PermissionSettingAttribute : Attribute
    {
        /// <summary>
        /// ����Ȩ��.
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