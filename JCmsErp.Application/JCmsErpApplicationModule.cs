using System.Reflection;
using Abp.Modules;
using Abp.AutoMapper;

namespace JCmsErp
{
    [DependsOn(typeof(JCmsErpCoreModule), typeof(AbpAutoMapperModule))]
    public class JCmsErpApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
