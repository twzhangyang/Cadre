using System;
using System.Collections.Generic;
using CadreManagement.Model;

namespace CadreManagement.ApplicationService.Contracts
{
    public interface IUserService : IApplicationService
    {
        UserModel GetUser(Guid id);

        Guid Register(UserModel userModel);

        bool Login(string email, string password);

        void ChangePassword(Guid id, string originalPassword, string newPassword);

        List<UserModel> GetUsers();
    }
}