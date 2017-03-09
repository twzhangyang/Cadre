using TypeLite;

namespace CadreManagement.Web.HyperMediaApi
{
    [TsInterface]
    public interface IHyperMediaCommandWithMetaInformation {        
        HyperMediaCommandMetaInformation CommandMetaInformation { get; set; }
    }
}