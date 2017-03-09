using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using CadreManagement.ApplicationService.Contracts;
using CadreManagement.ApplicationService.Exceptions;
using CadreManagement.Domain.User;
using CadreManagement.Model;
using CadreManagement.Repository.Contracts;

namespace CadreManagement.ApplicationService.Implements
{
    public class UserService :  IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel GetUser(Guid id)
        {
            Contract.Requires(id != Guid.Empty);

            var user = _userRepository.Get(id);

            return Transform(user);
        }

        private UserModel Transform(User user)
        {
            return new UserModel()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                LastLoginDateTime = user.LastLoginDateTime,
                RegisterDateTime = user.RegisterDateTime
            };
        }

        public Guid Register(UserModel userModel)
        {
            var existedUser = _userRepository.Find(x => x.Email.ToLower() == userModel.Email.ToLower()).FirstOrDefault();
            if (existedUser != null)
            {
                throw new DuplicateEmailException("email already exist, please input another one");
            }

            var user = User.Register(userModel);
            _userRepository.Add(user);

            return user.Id;
        }

        public bool Login(string email, string password)
        {
            var user = _userRepository.Find(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
            if (user == null)
            {
                throw new ApplicationServiceException("no such user");
            }
            if (!user.Login(password))
            {
                return false;
            }

            _userRepository.Update(user);

            return true;
        }

        public void ChangePassword(Guid id, string originalPassword, string newPassword)
        {
            var user = _userRepository.Get(id);

            user.ChangePassword(originalPassword, newPassword);

            _userRepository.Update(user);
        }

        public List<UserModel> GetUsers()
        {
            return _userRepository.GetAll().Select(Transform).ToList();
        }
    }
}