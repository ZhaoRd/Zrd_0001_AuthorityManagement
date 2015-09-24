using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityManagement.Presentations
{
    /// <summary>
    /// 实体DTO
    /// </summary>
    public abstract class EntityDto
    {
        /// <summary>
        /// 主键.
        /// </summary>
        public Guid Id{ get; set; }
    }
}
