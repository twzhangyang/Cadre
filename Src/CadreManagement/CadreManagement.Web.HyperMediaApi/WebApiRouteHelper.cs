using System.Configuration;
using System.Linq;
using System.Web;
using CadreManagement.Core.Extensions;

namespace CadreManagement.Web.HyperMediaApi
{
    public static class WebApiRouteHelper
    {
        public static string RootUri { get { return RootUriTemplate.FormatWith(Protocol, HostName); } }    
        private static string HostName { get { return HttpContext.Current.Request.Url.Host; } }
        private const string RootUriTemplate = "{0}://{1}/api";


        private static string Protocol
        {
            get
            {
                //var domainsString = ConfigurationManager.AppSettings["DomainsUsingSSL"] ?? string.Empty;
                //var domains = domainsString.Split(',').Select(me => me.Trim());
                //var useSSL = domains.Any(domain => !string.IsNullOrWhiteSpace(domain) && HttpContext.Current.Request.Url.Host.EndsWith(domain));
                //return useSSL ? "https" : "http";

                return "http";
            }
        }
    }
}