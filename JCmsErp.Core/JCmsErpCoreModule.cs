using System.Reflection;
using Abp.Modules;

namespace JCmsErp
{
    public class JCmsErpCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
