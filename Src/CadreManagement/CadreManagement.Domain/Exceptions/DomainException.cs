using CadreManagement.Core;

namespace CadreManagement.Domain.Exceptions
{
    public class DomainException : CadreManagementException
    {
        public DomainException(string message):base(message)
        {
            
        }
    }
}