using Abp.Application.Services;

namespace JCmsErp
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class JCmsErpAppServiceBase : ApplicationService
    {
        protected JCmsErpAppServiceBase()
        {
            LocalizationSourceName = JCmsErpConsts.LocalizationSourceName;
        }
    }
}