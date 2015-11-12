using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityManagement.Presentation.Attributes
{
    public class FunctionDescriptionAttribute : Attribute
    {
        public string FunctionName { get; set; }
    }

    public class NeedLoginedAttribute : Attribute
    {

    }
}
