using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityManagement.Applications
{
    using AuthorityManagement.Core.Domains;
    using AuthorityManagement.Presentation.Dtos;
    using AuthorityManagement.Presentations.RoleServices.Dtos;
    using AuthorityManagement.Presentations.UserServices.Dtos;

    using Skymate;
    using Skymate.Logging;

    /// <summary>
    /// The application startup.
    /// </summary>
    public class ApplicationStartup : IApplicationStartup
    {
        /// <summary>
        /// Gets the order.
        /// </summary>
        public int Order
        {
            get { return 999; }
        }

        /// <summary>
        /// The startup.
        /// </summary>
        public void Startup()
        {
            LogHelper.Logger.Info("应用层初始化");

            AutoMapper.Mapper.CreateMap<FunctionDto, Function>();
            AutoMapper.Mapper.CreateMap<Function, FunctionDto>();

            AutoMapper.Mapper.CreateMap<EditUserInputDto, User>();
            AutoMapper.Mapper.CreateMap<User, EditUserInputDto>();
            AutoMapper.Mapper.CreateMap<User, UserListOutputDto>()
                .ForMember(dto => dto.RoleNames, map => map.MapFrom(m => m.UserInRoles.Select(ur => ur.Role.RoleName)));

            AutoMapper.Mapper.CreateMap<RoleInputDto, Role>();
            AutoMapper.Mapper.CreateMap<Role, RoleInputDto>();
            AutoMapper.Mapper.CreateMap<Role, RoleListOutputDto>();
        }
    }
}
