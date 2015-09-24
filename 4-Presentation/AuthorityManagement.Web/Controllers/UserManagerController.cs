namespace AuthorityManagement.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;

    using AuthorityManagement.Presentation.Attributes;
    using AuthorityManagement.Presentations.UserServices;
    using AuthorityManagement.Presentations.UserServices.Dtos;
    using AuthorityManagement.Security;

    using Skymate;

    /// <summary>
    /// The user manager controller.
    /// </summary>
    [NeedLogined]
    [SystemModel("用户管理")]
    public class UserManagerController : Controller
    {
        /// <summary>
        /// The user service.
        /// </summary>
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManagerController"/> class.
        /// </summary>
        /// <param name="userService">
        /// The user service.
        /// </param>
        public UserManagerController(IUserService userService)
        {
            this.userService = userService;
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
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        [HttpPost]
        [ActionName("List")]
        public JsonResult SearchList(int pageIndex =1,int pageSize = 10)
        {
            var total = 0;

            var userList = this.userService.GetAllUser(pageIndex, pageSize, out total);

            return this.Json(
                OperationResult.Success(
                    string.Empty,
                    string.Empty,
                    new
                        {
                            Total = total,
                            PageSize = pageSize,
                            Data = userList }));
        }

        /// <summary>
        /// 获取新用户，若要对新增功能进行控制，则必须添加一个httpget方法才行
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [PermissionSetting(PermissionValue.Create)]
        public ActionResult Create()
        {
            var newUser = new EditUserInputDto();
            return this.Json(OperationResult.Success(string.Empty, string.Empty, newUser),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// The create post.
        /// </summary>
        /// <param name="userInput">
        /// The user input.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult SaveUser(EditUserInputDto userInput)
        {
            try
            {
                if (userInput.Id == Guid.Empty)
                {
                    this.userService.Add(userInput);
                }
                else
                {
                    this.userService.Update(userInput);
                }

                return this.Json(OperationResult.Success("保存成功"));
            }
            catch (Exception e)
            {
                return this.Json(OperationResult.Error("保存失败," + e.Message));
            }
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
            var user = this.userService.GetUserById(id);
            return this.Json(OperationResult.Success(string.Empty,string.Empty,user));
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
            this.userService.Delete(id);
            return this.Json(OperationResult.Success("删除成功"));
        }
    }
}
