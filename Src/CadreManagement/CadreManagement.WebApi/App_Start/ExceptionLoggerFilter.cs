using System.Web.Http.Filters;
using log4net;
using log4net.Core;

namespace CadreManagement.WebApi
{
    public class ExceptionLoggerFilter:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var log = LogManager.GetLogger(typeof(ExceptionLoggerFilter));

            log.Error(actionExecutedContext.Exception);
            base.OnException(actionExecutedContext);
        }
    }
}