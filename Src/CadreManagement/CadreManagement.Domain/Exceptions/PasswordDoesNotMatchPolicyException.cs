using System.Collections.Generic;

namespace CadreManagement.Domain.Exceptions
{
    public class PasswordDoesNotMatchPolicyException: DomainException
    {
        public IEnumerable<string> Failures { get; private set; }

        public PasswordDoesNotMatchPolicyException(IEnumerable<string> failures):base(string.Empty)
        {
            Failures = failures;
        }
    }
}