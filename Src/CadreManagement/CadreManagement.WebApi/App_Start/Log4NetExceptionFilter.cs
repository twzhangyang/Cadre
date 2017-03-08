using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace CadreManagement.WebApi
{
    public class Log4NetExceptionFilter:IExceptionFilter
    {
        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public bool AllowMultiple { get; }
    }
}