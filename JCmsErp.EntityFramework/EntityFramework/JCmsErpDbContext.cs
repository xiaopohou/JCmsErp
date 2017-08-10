using System.Data.Common;
using Abp.EntityFramework;
using System.Data.Entity;
using System;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.ModelConfiguration.Configuration;
using JCmsErp.User;
using JCmsErp.Meuns;

namespace JCmsErp.EntityFramework
{
    public class JCmsErpDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...

        //Example:
        //public virtual IDbSet<User> Users { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public JCmsErpDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in JCmsErpDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of JCmsErpDbContext since ABP automatically handles it.
         */
        public JCmsErpDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public JCmsErpDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public JCmsErpDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Add(new DecimalPrecisionAttributeConvention());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //移除复数表名

            modelBuilder.Entity<Users>().ToTable("[dbo].[Users]");
            modelBuilder.Entity<Meun>().ToTable("[dbo].[Modules]");

        }
        public virtual IDbSet<Users> User { get; set; }
        public virtual IDbSet<Meun> Modules { get; set; }


        public class DecimalPrecisionAttributeConvention : PrimitivePropertyAttributeConfigurationConvention<DecimalPrecisionAttribute>
        {
            public override void Apply(ConventionPrimitivePropertyConfiguration configuration, DecimalPrecisionAttribute attribute)
            {
                if (attribute.Precision < 1 || attribute.Precision > 38)
                {
                    throw new InvalidOperationException("Precision must be between 1 and 38.");
                }

                if (attribute.Scale > attribute.Precision)
                {
                    throw new InvalidOperationException("Scale must be between 0 and the Precision value.");
                }

                configuration.HasPrecision(attribute.Precision, attribute.Scale);
            }
        }
        [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
        public sealed class DecimalPrecisionAttribute : System.Attribute
        {
            public DecimalPrecisionAttribute(byte precision, byte scale)
            {
                Precision = precision;
                Scale = scale;
            }
            public byte Precision { get; set; }
            public byte Scale { get; set; }
        }

    }
}
