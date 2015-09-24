using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityManagement.Presentation.Attributes
{
    using AuthorityManagement.Security;

    public class FunctionDescriptionAttribute : Attribute
    {
        public string FunctionName { get; set; }
    }

    public class SystemModelAttribute : Attribute
    {
        private string name;

        private string groupName;

        public string Name {
            get
            {
                return name;
            }
        }

        public string GroupName {
            get
            {
                return groupName;
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

        private PermissionValue permissionValue;
        public PermissionValue PermissionValue {
            get
            {
                return permissionValue;
            }
        }

        public SystemModelAttribute(string name, PermissionValue permissionValue = PermissionValue.All, string groupName = null)
        {
            this.name = name;
            this.groupName = groupName;
            this.permissionValue = permissionValue;
        }


    }

    public class NeedLoginedAttribute : Attribute
    {

    }


    public class PermissionSettingAttribute : Attribute
    {
        private readonly PermissionValue permissionValue;

        public PermissionSettingAttribute(PermissionValue value)
        {
            this.permissionValue = value;
        }

        public PermissionValue PermissionValue
        {
            get
            {
                return permissionValue;
            }
        }

    }
}
