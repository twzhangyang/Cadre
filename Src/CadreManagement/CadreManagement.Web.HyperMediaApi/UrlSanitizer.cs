using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using CadreManagement.Core.Extensions;

namespace CadreManagement.Web.HyperMediaApi
{
    public static class UrlSanitizer
    {
        public static string SanitizeUrl(string link, RouteValueExtractor.RouteParameters routeValues)
        {
            link = EnsureLinkProtocolIsCorrect(link);
            link = HackToFixLinkHostName(link);

            return RemoveRedundantControllerAndActionArgumentsFromUrl(routeValues.RouteValueDictionary, link);
        }

        private static bool IsDomainUsingSSL()
        {
            var domainsString = ConfigurationManager.AppSettings["DomainsUsingSSL"] ?? string.Empty;
            var domains = domainsString.Split(',').Select(me => me.Trim());
            var useSSL = domains.Any(domain => !string.IsNullOrWhiteSpace(domain) && HttpContext.Current.Request.Url.Host.EndsWith(domain));
            return useSSL;
        }

        public static string EnsureLinkProtocolIsCorrect(string link)
        {
            if (IsDomainUsingSSL())
            {
                var uriBuilder = new UriBuilder(link)
                {
                    Scheme = Uri.UriSchemeHttps,
                    Port = -1 // default port for scheme
                };
                return uriBuilder.Uri.ToString();
            }
            return link;
        }

        private static string HackToFixLinkHostName(string link)
        {
            var correctHostSection = "//{0}/".FormatWith("cadreapi.local.com");
            var currentHostSection = "//{0}/".FormatWith(HttpContext.Current.Request.Url.Host);
            link = link.Replace(currentHostSection, correctHostSection);
            return link;
        }


        public static string RemoveRedundantControllerAndActionArgumentsFromUrl(IDictionary<string, object> routeValueDictionary, string link)
        {
            Contract.Requires(routeValueDictionary != null && link != null);

            var controller = routeValueDictionary["controller"];
            var action = routeValueDictionary["action"];

            var stringsToRemove = new[]
                                  {
                                      //If we have redundant things after the first query string parameter
                                      "&controller={0}".FormatWith(controller),
                                      "&action={0}".FormatWith(action),
                                      //if the redundant parameter is one of several 
                                      "controller={0}&".FormatWith(controller),
                                      "action={0}&".FormatWith(action),              
                                      //if the redundant argument is the only argument
                                      "?controller={0}".FormatWith(controller),
                                      "?action={0}".FormatWith(action)
                                  };

            stringsToRemove.ForEach(toRemove => link = link.Replace(toRemove, ""));
            
            return link;
        }
    }
}