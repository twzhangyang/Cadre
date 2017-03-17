using TypeLite;

namespace CadreManagement.Web.HyperMediaApi
{
    [TsClass]
    public class HyperMediaCommand<TResponseType>
    {
        protected HyperMediaCommand()
        {            
        }

        protected HyperMediaCommand(Link<TResponseType> postUrl)
        {
            PostUrl = postUrl;
        }

        public Link<TResponseType> PostUrl { get; set; }
    }
}