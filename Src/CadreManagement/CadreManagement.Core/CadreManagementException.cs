using System;

namespace CadreManagement.Core
{
    public class CadreManagementException : ApplicationException
    {
        public CadreManagementException(string message) : base(message)
        {
        }
    }
}