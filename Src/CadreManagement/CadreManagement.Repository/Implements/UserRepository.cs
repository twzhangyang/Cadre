using CadreManagement.Domain.User;
using CadreManagement.Repository.Contracts;
using CadreManagement.Repository.EntityFramework;

namespace CadreManagement.Repository.Implements
{
    public class UserRepository : EntityFrameworkRepository<User>, IUserRepository
    {
        public UserRepository(IEntityFrameworkContext efContext)
          : base(efContext)
        {
        }
    }
}