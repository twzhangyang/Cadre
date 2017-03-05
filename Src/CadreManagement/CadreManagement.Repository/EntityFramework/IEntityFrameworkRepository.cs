using CadreManagement.Core;

namespace CadreManagement.Repository.EntityFramework
{
    public interface IEntityFrameworkRepository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
        IEntityFrameworkContext EfContext { get; }
    }
}