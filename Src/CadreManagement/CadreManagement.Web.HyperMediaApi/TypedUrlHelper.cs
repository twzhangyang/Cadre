using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using CadreManagement.Core.Extensions;
using UrlHelper = System.Web.Http.Routing.UrlHelper;

namespace CadreManagement.Web.HyperMediaApi
{
    public static class TypedUrlHelper
    {
        public static Link<TResult> Link<TController, TResult>(this UrlHelper @this, Expression<Func<TController, TResult>> actionSelector)
            where TController : ApiController
        {
            return new Link<TResult>(GenerateLinkUrl<TController>(@this, actionSelector));
        }

        public static LinkTemplate1<TResult, TArgument1> LinkTemplate<TController, TArgument1, TResult>(this UrlHelper @this,
            Expression<Func<TController, TArgument1, TResult>> actionSelector) where TController : ApiController
        {
            return new LinkTemplate1<TResult, TArgument1>(GenerateLinkUrl<TController>(@this, actionSelector));
        }

        public static LinkTemplate2<TResult, TArgument1, TArgument2> LinkTemplate<TController, TArgument1, TArgument2, TResult>(this UrlHelper @this, Expression<Func<TController, TArgument1, TArgument2, TResult>> actionSelector)
             where TController : ApiController
        {
            return new LinkTemplate2<TResult, TArgument1, TArgument2>(GenerateLinkUrl<TController>(@this, actionSelector));
        }

        public static LinkTemplate3<TResult, TArgument1, TArgument2, TArgument3> LinkTemplate<TController, TArgument1, TArgument2, TArgument3, TResult>(this UrlHelper @this, Expression<Func<TController, TArgument1, TArgument2, TArgument3, TResult>> actionSelector)
             where TController : ApiController
        {
            return new LinkTemplate3<TResult, TArgument1, TArgument2, TArgument3>(GenerateLinkUrl<TController>(@this, actionSelector));
        }

        private static string GenerateLinkUrl<TController>(UrlHelper @this, LambdaExpression actionSelector) where TController : ApiController
        {
            var routeValues = RouteValueExtractor.ExtractHttpRouteParameters<TController>(actionSelector);
            routeValues.RouteValueDictionary.Add("httproute", routeValues.RouteName);

            var routeValuesWithoutControllerAndAction = new RouteValueDictionary(routeValues.RouteValueDictionary);
            routeValuesWithoutControllerAndAction.Remove("controller");
            routeValuesWithoutControllerAndAction.Remove("action");

            var virtualPath = RouteTable.Routes[routeValues.RouteName].GetVirtualPath(HttpContext.Current.Request.RequestContext, routeValuesWithoutControllerAndAction);
            var link = new Uri(new Uri(@this.Request.RequestUri.GetLeftPart(UriPartial.Authority)), virtualPath.VirtualPath).ToString();

            routeValues.ArgumentPlaceholders.ForEach(placeHolder =>
                link = link.Replace(placeHolder.Value.Value.ToString(), "{{{0}}}".FormatWith(placeHolder.Value.Index))
            );


            return UrlSanitizer.SanitizeUrl(link, routeValues);
        }

        //public static string Action<TController, TResult>(
        //    this UrlHelper @this,
        //    Expression<Func<TController, TResult>> actionSelector) where TController : Controller
        //{
        //    var routeValues = RouteValueExtractor.ExtractMvcRouteParameters<TController>(actionSelector);
        //    var virtualPath = RouteTable.Routes.GetVirtualPath(new HttpRequestWrapper(HttpContext.Current.Request).RequestContext, new RouteValueDictionary(routeValues.RouteValueDictionary));

        //    return virtualPath.VirtualPath;
        //}
    }
}
