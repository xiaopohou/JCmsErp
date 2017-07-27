using System.Data.Entity.Migrations;

namespace JCmsErp.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<JCmsErp.EntityFramework.JCmsErpDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "JCmsErp";
        }

        protected override void Seed(JCmsErp.EntityFramework.JCmsErpDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
