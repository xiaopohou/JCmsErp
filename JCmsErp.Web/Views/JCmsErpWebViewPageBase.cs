using Abp.Web.Mvc.Views;

namespace JCmsErp.Web.Views
{
    public abstract class JCmsErpWebViewPageBase : JCmsErpWebViewPageBase<dynamic>
    {

    }

    public abstract class JCmsErpWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected JCmsErpWebViewPageBase()
        {
            LocalizationSourceName = JCmsErpConsts.LocalizationSourceName;
        }
    }
}