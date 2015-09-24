using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityManagement.Presentations.Dtos.SecurityDtos
{
    public class FunctionPermissionOutputDto
    {
        public Guid FunctionId { get; set; }

        public string FunctionName { get; set; }

        public string FunctionGourpName { get; set; }

        public IList<string> PermissionNames { get; set; }

        public IList<FunctionPermisstionItemOutputDto> Items { get; set; }
    }

    public class FunctionPermisstionItemOutputDto
    {
        /// <summary>
        /// 权限值.
        /// </summary>
        public int PermissionValue{ get; set; }

        /// <summary>
        /// 权限名称.
        /// </summary>
        public string PermissionName { get; set; }

        /// <summary>
        /// 功能模块是否具有权限.
        /// </summary>
        public bool FunctionHasPermission { get; set; }

        /// <summary>
        /// 角色是否具有权限.
        /// </summary>
        public bool RoleHasPermission { get; set; }
    }

}
