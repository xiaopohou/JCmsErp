using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace JCmsErp.EntityFramework.Repositories
{
    public abstract class JCmsErpRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<JCmsErpDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected JCmsErpRepositoryBase(IDbContextProvider<JCmsErpDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class JCmsErpRepositoryBase<TEntity> : JCmsErpRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected JCmsErpRepositoryBase(IDbContextProvider<JCmsErpDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
