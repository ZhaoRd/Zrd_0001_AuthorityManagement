// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecurityDomainService.cs" company="">
//   
// </copyright>
// <summary>
//   The security domain service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AuthorityManagement.Core.Services
{
    using System;

    using Apworks.Specifications;

    using AuthorityManagement.Core.Domains;
    using AuthorityManagement.Core.Repositories;
    using AuthorityManagement.Security;

    /// <summary>
    /// The security domain service.
    /// </summary>
    public class SecurityDomainService : ISecurityDomainService
    {
        /// <summary>
        /// The function in role repository.
        /// </summary>
        private readonly IFunctionInRoleRepository functionInRoleRepository;

        /// <summary>
        /// The role repository.
        /// </summary>
        private readonly IRoleRepository roleRepository;

        /// <summary>
        /// The function repository.
        /// </summary>
        private readonly IFunctionRepository functionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityDomainService"/> class.
        /// </summary>
        /// <param name="functionInRoleRepository">
        /// The function in role repository.
        /// </param>
        /// <param name="roleRepository">
        /// The role repository.
        /// </param>
        /// <param name="functionRepository">
        /// The function repository.
        /// </param>
        public SecurityDomainService(IFunctionInRoleRepository functionInRoleRepository, IRoleRepository roleRepository, IFunctionRepository functionRepository)
        {
            this.functionInRoleRepository = functionInRoleRepository;
            this.roleRepository = roleRepository;
            this.functionRepository = functionRepository;
        }

        /// <summary>
        /// The verify permission.
        /// </summary>
        /// <param name="toVerification">
        /// The to verification.
        /// </param>
        /// <param name="functionInRole">
        /// The function in role.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool VerifyPermission(PermissionValue toVerification, 
            PermissionValue functionInRole)
        {
            return (toVerification & functionInRole) != 0;
        }

        /// <summary>
        /// The verify permission.
        /// </summary>
        /// <param name="functionId">
        /// The function id.
        /// </param>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        /// <param name="toVerification">
        /// The to verification.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool VerifyPermission(Guid functionId,
            Guid roleId,PermissionValue toVerification)
        {

            var spec = Specification<FunctionInRole>.Eval(u => u.Role.ID == roleId && u.Function.ID == functionId);

            var isexist = this.functionInRoleRepository.Exists(spec);

            // 不存在则表示未授权
            if (!isexist)
            {
                return false;
            }

            var functionInRole = this.functionInRoleRepository.Find(spec);

            return this.VerifyPermission(toVerification,functionInRole.PermissionValue);
        }

        /// <summary>
        /// The add authority.
        /// </summary>
        /// <param name="functionId">
        /// The function id.
        /// </param>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        /// <param name="toAddPermission">
        /// The to add permission.
        /// </param>
        public void AddAuthority(Guid functionId, Guid roleId, PermissionValue toAddPermission)
        {
            this.GuardAuthorityAgum(functionId,roleId, toAddPermission);

            var spec = Specification<FunctionInRole>.Eval(u => u.Role.ID == roleId && u.Function.ID == functionId);
            
            var isexist = this.functionInRoleRepository.Exists(spec);
            if (!isexist)
            {
                var role = this.roleRepository.GetByKey(roleId);
                var function = this.functionRepository.GetByKey(functionId);
                this.functionInRoleRepository.Add(new FunctionInRole()
                                                      {
                                                          ID = GuidHelper.GenerateGuid(), 
                                                          Role = role, 
                                                          Function = function, 
                                                          PermissionValue = toAddPermission
                                                      });
            }
            else
            {
                var functionInRole = this.functionInRoleRepository.Find(spec);

                // 或运算实现授权
                functionInRole.PermissionValue |= toAddPermission;
                this.functionInRoleRepository.Update(functionInRole);
            }

            // TODO:unitofwork模式
            this.functionInRoleRepository.Context.Commit();
        }

        /// <summary>
        /// The delete authority.
        /// </summary>
        /// <param name="functionId">
        /// The function id.
        /// </param>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        /// <param name="toRemovePermission">
        /// The to remove permission.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public void DeleteAuthority(Guid functionId,Guid roleId, PermissionValue toRemovePermission)
        {
            var spec = Specification<FunctionInRole>.Eval(u => u.Role.ID == roleId 
                && u.Function.ID == functionId);

            var isexist = this.functionInRoleRepository.Exists(spec);
            if (!isexist)
            {
                throw new Exception("尚未赋予权限");
            }

            var functionInRole = this.functionInRoleRepository.Find(spec);

            // 求补和与运算实现权限移除：value= value&(~toremove)
            functionInRole.PermissionValue &= ~toRemovePermission;
            this.functionInRoleRepository.Update(functionInRole);

            // TODO:应当使用unitofwork模式
            // 领域服务是否依赖仓储？
            this.functionInRoleRepository.Context.Commit();
        }

        /// <summary>
        /// The guard authority agum.
        /// </summary>
        /// <param name="functionId">
        /// The function id.
        /// </param>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        /// <param name="permissionValue">
        /// The permission value.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        private void GuardAuthorityAgum(Guid functionId,
            Guid roleId, PermissionValue permissionValue)
        {
            
            var functionIsExist = this.functionRepository.Exists(Specification<Function>.Eval(f => f.ID == functionId));
            var roleIsExist = this.roleRepository.Exists(Specification<Role>.Eval(u => u.ID == roleId));

            if (!functionIsExist || !roleIsExist)
            {
                throw new Exception("功能或角色不存在，请检查参数信息");
            }

            var function = this.functionRepository.GetByKey(functionId);
            if (!this.VerifyPermission(permissionValue, function.PermissionValue))
            {
                throw new Exception("该模块功能不具有需要添加的权限，禁止添加");
            }
        }

    }
}
