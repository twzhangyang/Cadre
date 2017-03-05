using CadreManagement.Core;

namespace CadreManagement.Repository.Exceptions
{
    public class NoSuchAggregateRootException: CadreManagementException
    {
        public NoSuchAggregateRootException(string message) : base(message)
        {
        }
    }
}