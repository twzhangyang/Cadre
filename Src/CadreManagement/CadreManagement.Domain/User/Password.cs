using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CadreManagement.Core.Extensions;
using CadreManagement.Domain.Exceptions;

namespace CadreManagement.Domain.User
{
    public class Password
    {
        public byte[] HashedPassword { get; private set; }
        public byte[] Salt { get; }

        public Password(string password)
        {
            AssertPasswordMatchesPolicy(password);

            Salt = Guid.NewGuid().ToByteArray();
            HashedPassword = HashPassword(salt: Salt, password: password);
        }

        public Password(byte[] password, byte[] salt)
        {
            Contract.Requires(password!=null);
            Contract.Requires(salt!=null);

            HashedPassword = password;
            Salt = salt;
        }

        public bool IsCorrectPassword(string password)
        {
            Contract.Requires(!password.IsNullOrEmpty());

            return HashedPassword.SequenceEqual(HashPassword(Salt, password));
        }

        private byte[] HashPassword(byte[] salt, string password)
        {
            var encodedPassword = Encoding.Unicode.GetBytes(password);
            var saltedPassword = salt.Concat(encodedPassword).ToArray();

            using (var algorithm = SHA256.Create())
            {
                return algorithm.ComputeHash(saltedPassword);
            }
        }

        private void AssertPasswordMatchesPolicy(string password)
        {
            if (password==null)
            {
                var error = Seq.Create("password can not be null");

                throw new PasswordDoesNotMatchPolicyException(error);
            }

            var errors = new List<string>();

            if (password.Trim().Length < 6)
            {
                errors.Add("password shorter than six characters");
            }
            if (password.ToLower() == password)
            {
                errors.Add("password missing uppercase characters");
            }
            if (password.ToUpper() == password)
            {
                errors.Add("password missing lowercase characters");
            }

            if (errors.Any())
            {
                throw new PasswordDoesNotMatchPolicyException(errors);
            }
        }
    }
}