using System.Data.Entity;
using CadreManagement.Core;

namespace CadreManagement.Repository.EntityFramework
{
    public class EntityFrameworkContext:IEntityFrameworkContext
    {
        public DbContext DbContext { get; }

        public EntityFrameworkContext(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void RegisterNew<TAggregateRoot>(TAggregateRoot obj) 
            where TAggregateRoot : class, IAggregateRoot
        {
            DbContext.Set<TAggregateRoot>().Add(obj);

        }

        public void RegisterModified<TAggregateRoot>(TAggregateRoot obj)
            where TAggregateRoot : class, IAggregateRoot
        {
            DbContext.Entry(obj).State = EntityState.Modified;
        }

        public void RegisterDeleted<TAggregateRoot>(TAggregateRoot obj)
            where TAggregateRoot : class, IAggregateRoot
        {
            DbContext.Set<TAggregateRoot>().Remove(obj);
        }

    }
}