using Abp.Web.Mvc.Controllers;

namespace JCmsErp.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class JCmsErpControllerBase : AbpController
    {
        protected JCmsErpControllerBase()
        {
            LocalizationSourceName = JCmsErpConsts.LocalizationSourceName;
        }
    }
}