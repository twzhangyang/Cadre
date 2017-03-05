using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CadreManagement.Core;
using CadreManagement.Repository.Exceptions;

namespace CadreManagement.Repository.EntityFramework
{
    public class EntityFrameworkRepository<TAggregateRoot> : IEntityFrameworkRepository<TAggregateRoot>
        where TAggregateRoot : class,IAggregateRoot
    {
        public IRepositoryContext Context => EfContext;

        public IEntityFrameworkContext EfContext { get; }

        public EntityFrameworkRepository(IEntityFrameworkContext efContext)
        {
            EfContext = efContext;
        }

        public TAggregateRoot Get(Guid key)
        {
            var dbset = EfContext.DbContext.Set<TAggregateRoot>();
            var aggregateRoot= dbset.FirstOrDefault(x => x.Id == key);
            if (aggregateRoot == null)
            {
                throw new NoSuchAggregateRootException($"Could not find aggregateRoot:{typeof(TAggregateRoot)} by id:{key}");
            }

            return aggregateRoot;
        }


        public void Add(TAggregateRoot aggregateRoot)
        {
            EfContext.RegisterNew(aggregateRoot);
        }

        public void Remove(TAggregateRoot aggregateRoot)
        {
            EfContext.RegisterDeleted(aggregateRoot);
        }

        public void Update(TAggregateRoot aggregateRoot)
        {
            EfContext.RegisterModified(aggregateRoot);
        }

        public IEnumerable<TAggregateRoot> GetAll()
        {
            var dbset = EfContext.DbContext.Set<TAggregateRoot>();
            return dbset;
        }

        public IEnumerable<TAggregateRoot> Find(Expression<Func<TAggregateRoot, bool>> conditions)
        {
            var dbset = EfContext.DbContext.Set<TAggregateRoot>().Where(conditions);
            return dbset;
        }
        
    }
}