namespace AuthorityManagement.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AuthorityManagement.Presentation.Attributes;
    using AuthorityManagement.Presentations.PermissionServices;
    using AuthorityManagement.Presentations.RoleServices;
    using AuthorityManagement.Security;

    using Skymate;

    /// <summary>
    /// The permission manager controller.
    /// </summary>
    [NeedLogined]
    [SystemModel("权限管理")]
    public class PermissionManagerController : Controller
    {
        /// <summary>
        /// The role service.
        /// </summary>
        private readonly IRoleService roleService;

        /// <summary>
        /// The permission service.
        /// </summary>
        private readonly IPermissionService permissionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionManagerController"/> class.
        /// </summary>
        /// <param name="roleService">
        /// The role service.
        /// </param>
        /// <param name="permissionService">
        /// The permission service.
        /// </param>
        public PermissionManagerController(IRoleService roleService, IPermissionService permissionService)
        {
            this.roleService = roleService;
            this.permissionService = permissionService;
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return this.RedirectToAction("List");
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [AllowAnonymous]
        [PermissionSetting(PermissionValue.Lookup)]
        public ActionResult List()
        {
            return this.View();
        }

        /// <summary>
        /// 获取所有用户角色.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult GetAllRoles()
        {
            var list = this.roleService.GetAllRoles();
            return this.Json(OperationResult.Success(string.Empty, string.Empty, list),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取所有权限描述
        /// </summary>
        /// <returns></returns>
        public ActionResult PermissionDescription()
        {
            // 获取权限以及权限说明,用于显示表头
            var list =
                typeof(PermissionValue).ToList()
                    .Where(
                        u =>
                        (PermissionValue)u.Enum != PermissionValue.All
                        && (PermissionValue)u.Enum != PermissionValue.None);
            return this.Json(OperationResult.Success(string.Empty, string.Empty, list), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据角色ID获取权限列表.
        /// </summary>
        /// <param name="roleId">
        /// 角色ID.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult GetPermissionList(Guid roleId)
        {
            var list = this.permissionService.GetPermissionList(roleId);
            return this.Json(OperationResult.Success(string.Empty, string.Empty, list));
        }

        /// <summary>
        /// 授权.
        /// </summary>
        /// <param name="acceditInput">
        /// 授权信息.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult Allow(AccreditInputDto acceditInput)
        {
            this.permissionService.Accredit(acceditInput);
            return this.Json(OperationResult.Success());
        }

        /// <summary>
        /// 取消权限.
        /// </summary>
        /// <param name="acceditInput">
        /// 授权信息.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult Forbid(AccreditInputDto acceditInput)
        {
            this.permissionService.Forbid(acceditInput);
            return this.Json(OperationResult.Success());
        }
    }
}
