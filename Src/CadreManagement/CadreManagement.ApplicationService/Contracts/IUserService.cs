using System;
using CadreManagement.DomainModel;

namespace CadreManagement.ApplicationService.Contracts
{
    public interface IUserService : IApplicationService
    {
        Guid Register(UserModel userModel);

        bool Login(string email, string password);

        void ChangePassword(Guid id, string originalPassword, string newPassword);
    }
}