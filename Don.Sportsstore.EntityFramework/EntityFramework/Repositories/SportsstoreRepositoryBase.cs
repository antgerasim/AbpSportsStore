using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Don.Sportsstore.EntityFramework.Repositories
{
    public abstract class SportsstoreRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<SportsstoreDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected SportsstoreRepositoryBase(IDbContextProvider<SportsstoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class SportsstoreRepositoryBase<TEntity> : SportsstoreRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected SportsstoreRepositoryBase(IDbContextProvider<SportsstoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
