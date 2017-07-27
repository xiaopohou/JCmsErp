using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace JCmsErp
{
    [DependsOn(typeof(AbpWebApiModule), typeof(JCmsErpApplicationModule))]
    public class JCmsErpWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(JCmsErpApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
