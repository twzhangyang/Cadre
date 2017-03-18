using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using CadreManagement.Core.Extensions;
using Manpower.Applications.Shared.HyperMediaApi.Json;
using Newtonsoft.Json;

namespace CadreManagement.Web.HyperMediaApi
{
    public class LinkNavigator<TResource>
    {
        private readonly HttpServer _server;
        public Link<TResource> Link { get; set; }

        protected LinkNavigator(HttpServer server)
        {
            _server = server;
        }

        public LinkNavigator(Link<TResource> startLink, HttpServer server)
        {
            _server = server;
            Link = startLink;
        }

        public virtual TResource Execute()
        {
            return FetchUri(Link);
        }

        protected TResourceToFetch FetchUri<TResourceToFetch>(Link<TResourceToFetch> link)
        {
            var requestInvoker = new HttpMessageInvoker(_server);
            using (var request = new HttpRequestMessage(HttpMethod.Get, link.Uri))
            {
                request.SetConfiguration(_server.Configuration);

                var cts = new CancellationTokenSource();
                using (var response = requestInvoker.SendAsync(request, cts.Token))
                {
                    using (var result = response.Result)
                    {
                        using (var httpContent = result.Content)
                        {
                            var resultData = httpContent.ReadAsStringAsync().Result;
                            if (result.IsSuccessStatusCode == false)
                            {
                                var exceptionMessage = "Http operation unsuccessful\nStatus: '{0}'\"Reason: '{1}'\n\nResponse:\n{2}".FormatWith(result.StatusCode,
                                    result.ReasonPhrase,
                                    resultData);
                                throw new Exception(exceptionMessage);
                            }

                            var fetchedResource = DeserializeJson<TResourceToFetch>(resultData);

                            return fetchedResource;
                        }
                    }
                }
            }
        }

        public TResultResource PostCommand<TResultResource>(HyperMediaCommand<TResultResource> command)
        {
            var requestInvoker = new HttpMessageInvoker(_server);
            using (var request = new HttpRequestMessage(HttpMethod.Post, command.PostUrl.Uri))
            {
                request.Content=new ObjectContent(command.GetType(),command,new JsonMediaTypeFormatter());
                request.SetConfiguration(_server.Configuration);

                var cts = new CancellationTokenSource();
                using (var response = requestInvoker.SendAsync(request, cts.Token))
                {
                    using (var result = response.Result)
                    {
                        using (var httpContent = result.Content)
                        {
                            var resultData = httpContent.ReadAsStringAsync().Result;
                            if (result.IsSuccessStatusCode == false)
                            {
                                var exceptionMessage = "Http operation unsuccessful\nStatus: '{0}'\"Reason: '{1}'\n\nResponse:\n{2}".FormatWith(result.StatusCode,
                                    result.ReasonPhrase,
                                    resultData);
                                throw new Exception(exceptionMessage);
                            }

                            var fetchedResource = DeserializeJson<TResultResource>(resultData);

                            return fetchedResource;
                        }
                    }
                }
            }
        }

        public SubLinkNavigator<TTargetResource, TResource> FollowLink<TTargetResource>(Func<TResource, Link<TTargetResource>> navigator)
        {
            return new SubLinkNavigator<TTargetResource, TResource>(this, navigator, _server);
        }

        public SubLinkNavigator<TTargetResource, TResource> FollowLinkTemplate<TTargetResource, TArgument>(Func<TResource, LinkTemplate1<TTargetResource, TArgument>> navigator, TArgument argument)
        {
            return new SubLinkNavigator<TTargetResource, TResource>(this, (resource) => navigator(resource).CreateLink(argument), _server);
        }

        private static TResultResource DeserializeJson<TResultResource>(string responseText)
        {
            return JsonConvert.DeserializeObject<TResultResource>(responseText, JsonSettings.JsonSerializerSettings);
        }
    }
}