using System;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace CadreManagement.Web.HyperMediaApi
{
    public class LinkNavigator<TResource>
    {
        private readonly Link<TResource> _startLink;

        protected LinkNavigator() { }

        public LinkNavigator(Link<TResource> startLink)
        {
            _startLink = startLink;
        }

        protected TTargetResource FetchUri<TTargetResource>(Link<TTargetResource> link)
        {
            using (var client = new HttpClient())
            {
                return JsonConvert.DeserializeObject<TTargetResource>(client.GetStringAsync(link.Uri).Result);
            }
        }

        public SubLinkNavigator<TTargetResource, TResource> FollowLink<TTargetResource>(
            Func<TResource, Link<TTargetResource>> navigator)
        {
            return new SubLinkNavigator<TTargetResource, TResource>(this,navigator);
        }

        public SubLinkNavigator<TTargetResource,TResource> FollowWithTemplate<TTargetResource,TArgument1>(Func<TResource,LinkTemplate1<TTargetResource, TArgument1>> navigator, TArgument1 argument1)
        {
            return new SubLinkNavigator<TTargetResource, TResource>(this, resource=>navigator(resource).CreateLink(argument1));
        }

        public virtual  TResource Execute()
        {
            return FetchUri(_startLink);
        }

        public TResultResponse PostCommand<TResultResponse>(HyperMediaCommand<TResultResponse> command)
        {
            using (var client = new HttpClient())
            {
                var responseMessage = client.PostAsJsonAsync(new Uri(command.PostUrl.Uri), command).Result;
                var responseText = responseMessage.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<TResultResponse>(responseText);
            }
        }

    }
}