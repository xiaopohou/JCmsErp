using JCmsErp.Meuns;
using JCmsErp.Web.Areas.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JCmsErp.Web.Areas.Common.Controllers
{
    public class LayoutController : Controller
    {
        List<MeunDto> modules = new List<MeunDto>
            {
                new  MeunDto { Id = 1, ParentId = null, Name = "授权管理", Code = 200,LinkUrl="/Member/Role/Index",  Description = null, IsMenu = true, Enabled = true,  UpdateDate = DateTime.Now},
                new  MeunDto { Id = 2, ParentId = 1, Name = "角色管理", LinkUrl = "/Member/Role/Index",  Code = 201,Description = null, IsMenu = true, Enabled = true, UpdateDate = DateTime.Now},
                new  MeunDto { Id = 3, ParentId = 1, Name = "用户管理", LinkUrl = "/Member/Role/Index", Code = 202, Description = null, IsMenu = true, Enabled = true, UpdateDate = DateTime.Now },
                new  MeunDto { Id = 4, ParentId = 1, Name = "模块管理", LinkUrl = "/Member/Role/Index",  Code = 204, Description = null, IsMenu = true, Enabled = true,  UpdateDate = DateTime.Now },
                new  MeunDto { Id = 5, ParentId = 1, Name = "权限管理", LinkUrl = "/Member/Role/Index",  Code = 205, Description = null, IsMenu = true, Enabled = true,  UpdateDate = DateTime.Now },
                 new  MeunDto { Id = 6, ParentId = null, Name = "系统应用", LinkUrl = "#",  Code = 300,  Description = null, IsMenu = true, Enabled = true,  UpdateDate = DateTime.Now },
                new  MeunDto { Id = 7, ParentId = 6, Name = "操作日志管理", LinkUrl = "#",Code = 301,Description = null, IsMenu = true, Enabled = true,  UpdateDate = DateTime.Now },
                new  MeunDto { Id = 8, ParentId = 1, Name = "用户组管理", LinkUrl = "/Member/Role/Index",  Code = 203, Description = null, IsMenu = true, Enabled = true,  UpdateDate = DateTime.Now }
            };
        public ActionResult _Layout()
        {
            ViewBag.SidebarMenuModel = modules;
            return View();
        }
        public ActionResult _LeftSideMenus()
        {
            MeunViewModel model = new MeunViewModel();
            model._LPBasicSet = modules;
            return PartialView("_LeftSideMenus", model);
        }
        public ActionResult _MainFooter()
        {
            return PartialView("_MainFooter");
        }
        public ActionResult _MainHeader()
        {
            return PartialView("_MainHeader");
        }

    }
}