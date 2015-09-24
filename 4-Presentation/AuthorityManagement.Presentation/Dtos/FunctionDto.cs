using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityManagement.Presentation.Dtos
{
    using AuthorityManagement.Security;

    public class FunctionDto
    {
        public Guid ID { get; set; }

        public string ModelName { get; set; }

        public string FunctionName { get; set; }

        public string Description { get; set; }

        public string AreasName { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public int FunctionType { get; set; }

        public PermissionValue PermissionValue { get; set; }
    }
}
