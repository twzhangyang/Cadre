using System;
using CadreManagement.Core;

namespace CadreManagement.Domain.User
{
    public partial class User : AggregateRoot<User>
    {
        public string Name { get;private set; }

        public byte[] Password { get; private set; }

        public byte[] Salt { get; private set; }

        public string Email { get; private set; }

        public DateTime RegisterDateTime { get; private set; }

        public DateTime LastLoginDateTime { get; private set; }

    }
}