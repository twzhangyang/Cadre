using System.Data.Entity;
using CadreManagement.Core;

namespace CadreManagement.Repository.EntityFramework
{
    public interface IEntityFrameworkContext : IRepositoryContext
    {
        DbContext DbContext { get; }
    }
}