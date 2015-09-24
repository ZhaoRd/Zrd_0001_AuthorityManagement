using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityManagement.Core.Specifications
{
    using System.Linq.Expressions;

    using Apworks.Specifications;

    using AuthorityManagement.Core.Domains;

    /// <summary>
    /// The function area controller action specification.
    /// </summary>
    public class FunctionAreaControllerActionSpecification
        :Specification<Function>
    {
        public string Area { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public FunctionAreaControllerActionSpecification(
            string controllerName, string actionName, string areaName=null)
        {
            this.Area = areaName;
            this.Controller = controllerName;
            this.Action = actionName;
        }

        public override Expression<Func<Function, bool>> GetExpression()
        {
            if (string.IsNullOrEmpty(this.Area))
            {
                return c => (c.ActionName == this.Action && this.Controller == c.ControllerName);
            }

            return c => (c.ActionName == this.Action && this.Controller == c.ControllerName) && c.AreasName == this.Area;   
        }
    }

    public class FunctionNameSpectionfication : Specification<Function>
    {
        public string GroupName { get;private set; }

        public string FunctionName { get;private set; }

        public FunctionNameSpectionfication(
            string functionName,string groupName)
        {
            this.FunctionName = functionName;
            this.GroupName = groupName;
        }

        public override Expression<Func<Function, bool>> GetExpression()
        {
            if (string.IsNullOrEmpty(this.GroupName))
            {
                return c => (c.FunctionName==this.FunctionName&&c.ModelName==null);
            }

            return c => c.FunctionName==this.FunctionName&&c.ModelName==this.GroupName;
        }
    }


}
