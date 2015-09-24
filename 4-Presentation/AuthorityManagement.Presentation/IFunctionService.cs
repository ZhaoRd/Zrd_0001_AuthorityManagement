using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityManagement.Presentation
{
    using AuthorityManagement.Presentation.Dtos;

    public interface IFunctionService
    {
        void InitModel(IEnumerable<FunctionDto> functionDtos);

        FunctionDto SearFunction(SearchFunctionInputDto inputDto);

        bool VerifyPermission(Guid userId,Guid functionId);

    }

    public class SearchFunctionInputDto 
    {
        public string GroupName { get; set; }

        public string ModelName { get; set; }

    }
}
