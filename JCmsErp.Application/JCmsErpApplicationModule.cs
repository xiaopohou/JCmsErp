using System.Reflection;
using Abp.Modules;

namespace JCmsErp
{
    [DependsOn(typeof(JCmsErpCoreModule))]
    public class JCmsErpApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
