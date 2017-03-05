using CadreManagement.Core;

namespace CadreManagement.ApplicationService.Exceptions
{
    public class ApplicationServiceException: CadreManagementException
    {
        public ApplicationServiceException(string message):base(message)
        {
            
        }
    }
}