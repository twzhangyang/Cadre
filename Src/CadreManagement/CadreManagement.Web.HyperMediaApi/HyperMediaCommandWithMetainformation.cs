using TypeLite;

namespace CadreManagement.Web.HyperMediaApi
{
    [TsClass]
    public class HyperMediaCommandWithMetainformation<TResponseType> : HyperMediaCommand<TResponseType>, IHyperMediaCommandWithMetaInformation
    {
        protected HyperMediaCommandWithMetainformation() {}

        protected HyperMediaCommandWithMetainformation(
            Link<TResponseType> postLink) : base(postLink)
        {
        }

        public HyperMediaCommandMetaInformation CommandMetaInformation { get; set; }
    }
}
