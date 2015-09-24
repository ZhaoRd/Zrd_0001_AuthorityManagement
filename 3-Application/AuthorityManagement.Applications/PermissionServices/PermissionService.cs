namespace AuthorityManagement.Applications.PermissionServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AuthorityManagement.Core.Repositories;
    using AuthorityManagement.Core.Services;
    using AuthorityManagement.Presentations.PermissionServices;
    using AuthorityManagement.Presentations.PermissionServices.Dtos;
    using AuthorityManagement.Security;

    using Skymate;

    using IPermissionService = AuthorityManagement.Presentations.PermissionServices.IPermissionService;

    /// <summary>
    /// The permission service.
    /// </summary>
    public class PermissionService : IPermissionService
    {
        /// <summary>
        /// The function repository.
        /// </summary>
        private readonly IFunctionRepository functionRepository;

        /// <summary>
        /// The security domain service.
        /// </summary>
        private readonly ISecurityDomainService securityDomainService;

        /// <summary>
        /// The function in role repository.
        /// </summary>
        private readonly IFunctionInRoleRepository functionInRoleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionService"/> class.
        /// </summary>
        /// <param name="functionRepository">
        /// The function repository.
        /// </param>
        /// <param name="securityDomainService">
        /// The security domain service.
        /// </param>
        /// <param name="functionInRoleRepository">
        /// The function in role repository.
        /// </param>
        public PermissionService(IFunctionRepository functionRepository, ISecurityDomainService securityDomainService, IFunctionInRoleRepository functionInRoleRepository)
        {
            this.functionRepository = functionRepository;
            this.securityDomainService = securityDomainService;
            this.functionInRoleRepository = functionInRoleRepository;
        }

        /// <summary>
        /// The get permission list.
        /// </summary>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<PermissionOutputDto> GetPermissionList(Guid roleId)
        {
            var query = this.functionRepository.FindAll();

            var functionRole = this.functionInRoleRepository.FindAll().Where(u => u.Role.ID == roleId).ToList();

            var result = query.Select(f => new PermissionOutputDto
                                               {
                                                   FunctionId = f.ID,
                                                   FunctionName = f.FunctionName,
                                                   FunctionPermissionValue = f.PermissionValue
                                               }).ToList();
            result = result.Select( 
                perOutput =>
                    {
                        perOutput.PermissionEnum =
                            typeof(PermissionValue).ToValueList()
                                .Where(
                                    u =>
                                    (PermissionValue)u != PermissionValue.All
                                    && (PermissionValue)u != PermissionValue.None)
                                .Select(pv =>
                                  {
                                      var firstOrDefault =
                                          functionRole.FirstOrDefault(u => u.Function.ID == perOutput.FunctionId);

                                      return new PermissionEnumDto
                                                 {
                                                     PermissionValue = pv,

                                                     // 功能是否拥有权限
                                                     FunctionHas =
                                                         this.securityDomainService.VerifyPermission(
                                                             (PermissionValue)pv,
                                                             perOutput.FunctionPermissionValue),

                                                    // 角色使用拥有权限 
                                                    RoleHas =
                                                         firstOrDefault != null
                                                         && this.securityDomainService.VerifyPermission(
                                                             (PermissionValue)pv,
                                                              firstOrDefault.PermissionValue)
                                                 };
                                  });
                        return perOutput;
                    }).ToList();
            
            return result;
        }

        /// <summary>
        /// The accredit.
        /// </summary>
        /// <param name="accreditInput">
        /// The accredit input.
        /// </param>
        public void Accredit(AccreditInputDto accreditInput)
        {
            Guard.ArgumentNotNull(() => accreditInput);
            this.securityDomainService.AddAuthority(
                accreditInput.FunctionId,
                accreditInput.RoleId,
                accreditInput.PermissionValue);
        }

        /// <summary>
        /// The forbid.
        /// </summary>
        /// <param name="accreditInput">
        /// The accredit input.
        /// </param>
        public void Forbid(AccreditInputDto accreditInput)
        {
            Guard.ArgumentNotNull(() => accreditInput);
            this.securityDomainService.DeleteAuthority(
                accreditInput.FunctionId,
                accreditInput.RoleId,
                accreditInput.PermissionValue);
        }
    }
}
