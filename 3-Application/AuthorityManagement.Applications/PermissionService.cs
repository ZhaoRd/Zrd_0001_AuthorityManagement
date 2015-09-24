using System.Linq;

namespace AuthorityManagement.Presentations
{
    using Apworks.Specifications;

    using AuthorityManagement.Core.Domains;
    using AuthorityManagement.Core.Repositories;
    using AuthorityManagement.Core.Services;
    using AuthorityManagement.Security;

    public class PermissionService:IPermissionService
    {
        public readonly IFunctionInRoleRepository functionInRoleRepository;

        public readonly IUserInRoleRepository userInRoleRepository;

        public readonly ISecurityDomainService SecurityDomainService;

        public PermissionService(IFunctionInRoleRepository functionInRoleRepository, IUserInRoleRepository userInRoleRepository, ISecurityDomainService securityDomainService)
        {
            this.functionInRoleRepository = functionInRoleRepository;
            this.userInRoleRepository = userInRoleRepository;
            this.SecurityDomainService = securityDomainService;
        }

        public bool VerifyAuthority(VerifyAuthorityInputDto verifyAuthorityInputDto)
        {
            ISpecification<FunctionInRole> spec =
                Specification<FunctionInRole>.Eval(
                    f => f.Function.FunctionName == verifyAuthorityInputDto.SystemModelName);

            // 如果功能模块所在分组为空，则查询记录系统模块名为空的记录
            spec.And(
                string.IsNullOrEmpty(verifyAuthorityInputDto.GroupName)
                    ? Specification<FunctionInRole>.Eval(u => u.Function.ModelName == null)
                    : Specification<FunctionInRole>.Eval(u => u.Function.ModelName == verifyAuthorityInputDto.GroupName));

            // 查询所有角色id
            var roleIds =
                this.userInRoleRepository.FindAll()
                    .Where(u => u.User.ID == verifyAuthorityInputDto.LoginUserId)
                    .Select(u => u.Role.ID);

            spec.And(Specification<FunctionInRole>.Eval(u => roleIds.Contains(u.Role.ID)));

            var hasAuthorized = this.functionInRoleRepository.Exists(spec);
            
            // 未角色进行授权
            if (!hasAuthorized)
            {
                return false;
            }

            var permissionValue =
                this.functionInRoleRepository.FindAll().Where(spec.GetExpression()).Select(u => u.PermissionValue);

            // 获取所有角色具有的所有权限
            var roleAllPermission = Enumerable.Aggregate(permissionValue, PermissionValue.None, (current, value) => current | value);

            // 需要验证的权限是否在全部角色中
            return this.SecurityDomainService.VerifyPermission(
                verifyAuthorityInputDto.PermissionValue,
                roleAllPermission);
        }
    }
}
