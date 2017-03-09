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

        //[Obsolete("Do not ask me why, but having this property here makes the type detection for postCommand in the typescript api navigator work. Without it it does not. Go figure", true)]
        //public Link<TResponseType> ResultTypeProviderTypeScriptGenericsOddityWorkaroundAlwaysNull { get; set; }

        public Link<TResponseType> PostUrl { get; set; }
    }
}