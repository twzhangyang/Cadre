namespace CadreManagement.ApplicationService.Exceptions
{
    public class DuplicateEmailException:ApplicationServiceException
    {
        public DuplicateEmailException(string message) : base(message)
        {
        }
    }
}