using System.Web.Mvc;

namespace JCmsErp.Web.Controllers
{
    public class HomeController : JCmsErpControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}