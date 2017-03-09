using System;
using System.Linq.Expressions;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace CadreManagement.Web.HyperMediaApi
{
    public static class TypedMvcUrlHelper
    {
        public static Link<TResource> HttpLink<TController, TResource>(this UrlHelper @this, Expression<Func<TController, TResource>> actionSelector) where TController : ApiController
        {
            return new Link<TResource>(GenerateHttpLinkUrl<TController>(@this, actionSelector));
        }

        private static string GenerateHttpLinkUrl<TController>(UrlHelper @this, LambdaExpression actionSelector) where TController : ApiController
        {
            var routeValues = RouteValueExtractor.ExtractHttpRouteParameters<TController>(actionSelector);
            var routeValuesWithoutControllerAndAction = new RouteValueDictionary(routeValues.RouteValueDictionary);
            routeValuesWithoutControllerAndAction.Remove("controller");
            routeValuesWithoutControllerAndAction.Remove("action");
            var link = @this.HttpRouteUrl(routeValues.RouteName, new RouteValueDictionary(routeValuesWithoutControllerAndAction));

            var hostAndProtocol = @this.RequestContext.HttpContext.Request.Url.GetLeftPart(UriPartial.Authority);

            link = new Uri(new Uri(hostAndProtocol), link).ToString();

            return UrlSanitizer.SanitizeUrl(link, routeValues);
        }
    }
}
