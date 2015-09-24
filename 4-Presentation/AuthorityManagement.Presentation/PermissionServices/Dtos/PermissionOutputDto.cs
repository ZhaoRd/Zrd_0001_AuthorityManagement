using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityManagement.Presentations.PermissionServices.Dtos
{
    using AuthorityManagement.Presentation.Dtos;
    using AuthorityManagement.Security;

    /// <summary>
    /// 权限输出DTO.
    /// </summary>
    public class PermissionOutputDto:IOutputDto
    {
        /// <summary>
        /// 功能名称.
        /// </summary>
        public string FunctionName { get; set; }

        /// <summary>
        /// 功能ID.
        /// </summary>
        public Guid FunctionId { get; set; }

        /// <summary>
        /// 功能的权限值.
        /// </summary>
        public PermissionValue FunctionPermissionValue { get; set; }

        /// <summary>
        /// 功能具有的具体权限.
        /// </summary>
        public IEnumerable<PermissionEnumDto> PermissionEnum { get; set; }
    }
}
