// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoleManagerController.cs" company="">
//   
// </copyright>
// <summary>
//   The role manager controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AuthorityManagement.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using AuthorityManagement.Presentation.Attributes;
    using AuthorityManagement.Presentations.RoleServices;
    using AuthorityManagement.Presentations.RoleServices.Dtos;
    using AuthorityManagement.Security;

    using Skymate;

    /// <summary>
    /// The role manager controller.
    /// </summary>
    [NeedLogined]
    [SystemModel("角色管理")]
    public class RoleManagerController : Controller
    {
        /// <summary>
        /// The role service.
        /// </summary>
        private readonly IRoleService roleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleManagerController"/> class.
        /// </summary>
        /// <param name="roleService">
        /// The role service.
        /// </param>
        public RoleManagerController(IRoleService roleService)
        {
            this.roleService = roleService;
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
        [PermissionSetting(PermissionValue.Lookup)]
        public ActionResult List()
        {
            return this.View();
        }

        /// <summary>
        /// The search list.
        /// </summary>
        /// <param name="pageIndex">
        /// The page index.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        [HttpPost]
        [ActionName("List")]
        public JsonResult SearchList(int pageIndex = 1, int pageSize = 10)
        {
            var total = 0;

            var userList = this.roleService.GetAllRoles(pageIndex, pageSize, out total);

            return this.Json(
                OperationResult.Success(
                    string.Empty,
                    string.Empty,
                    new
                        {
                            Total = total,
                
                Data = userList
            }));
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [PermissionSetting(PermissionValue.Create)]
        public ActionResult Create()
        {
            var newRole = new RoleInputDto();
            return this.Json(OperationResult.Success(string.Empty, string.Empty, newRole), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [PermissionSetting(PermissionValue.Edit)]
        public ActionResult Edit(Guid id)
        {
            var user = this.roleService.GetRoleById(id);
            return this.Json(OperationResult.Success(string.Empty, string.Empty, user),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// The save role.
        /// </summary>
        /// <param name="roleInput">
        /// The role input.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult SaveRole(RoleInputDto roleInput)
        {
            if (!ModelState.IsValid)
            {
                return this.Json(OperationResult.Error("输入值有错误"));
            }

            try
            {
                if (roleInput.Id == Guid.Empty)
                {
                    this.roleService.Add(roleInput);
                }
                else
                {
                    this.roleService.Update(roleInput);
                }

                return this.Json(OperationResult.Success("保存成功"));
            }
            catch (Exception e)
            {
                return this.Json(OperationResult.Error("保存失败," + e.Message));
            }
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [PermissionSetting(PermissionValue.Delete)]
        public ActionResult Delete(Guid id)
        {
            this.roleService.Delete(id);
            return this.Json(OperationResult.Success("删除成功"));
        }

    }
}
