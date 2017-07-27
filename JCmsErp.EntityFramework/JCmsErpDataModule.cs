using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using JCmsErp.EntityFramework;

namespace JCmsErp
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(JCmsErpCoreModule))]
    public class JCmsErpDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<JCmsErpDbContext>(null);
        }
    }
}
