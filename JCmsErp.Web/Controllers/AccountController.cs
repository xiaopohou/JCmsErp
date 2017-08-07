using Abp.Web.Mvc.Controllers;
using JCmsErp.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JCmsErp.Web.Controllers
{
    public class AccountController : AbpController
    {

        private readonly IUserService _iUsersService;

        public AccountController(IUserService iUsersService)

        {
            _iUsersService = iUsersService;

        }
        // GET: Account
        public ActionResult Index()
        {

            return View();
        }
        //登陆处理

        //[DontWrapResult]
        //登陆处理
        [HttpPost]
        public JsonResult Login(string userName, string password)
        {
            try
            {
                if (!_iUsersService.Login(userName, password))
                {
                    return Json(new { success = false, Msg = "登录密码错误或用户不存在或用户被禁用" }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                Logger.Error("登录错误" + ex);
                ModelState.AddModelError("_error", "登录密码错误或用户不存在或用户被禁用。");
            }
            return Json(new { success = true, Msg = "登录成功!" }, JsonRequestBehavior.AllowGet);
        }

    }
}