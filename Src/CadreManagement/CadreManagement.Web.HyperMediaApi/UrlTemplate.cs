using CadreManagement.Core.Extensions;
using Newtonsoft.Json;
using TypeLite;

namespace CadreManagement.Web.HyperMediaApi
{
    [TsClass]
    public class UrlTemplate1<TArgument1>
    {
        [JsonProperty]
        public string UrlTemplate { get; private set; }

        public UrlTemplate1(string urlTemplate)
        {
            UrlTemplate = urlTemplate;
        }

        public string CreateUrl(TArgument1 argument1)
        {
            return UrlTemplate.FormatWith(argument1);
        }

        public string CreateUrlUnsafe(object argument1)
        {
            return UrlTemplate.FormatWith(argument1);
        }
    }

    [TsClass]
    public class UrlTemplate2<TArgument1, TArgument2>
    {
        [JsonProperty]
        public string UrlTemplate { get; private set; }

        public UrlTemplate2(string urlTemplate)
        {
            UrlTemplate = urlTemplate;
        }

        public string CreateUrl(TArgument1 argument1, TArgument2 argument2)
        {
            return UrlTemplate.FormatWith(argument1, argument2);
        }

        public string CreateUrlUnsafe(object argument1, object argument2)
        {
            return UrlTemplate.FormatWith(argument1, argument2);
        }
    }

    [TsClass]
    public class UrlTemplate3<TArgument1, TArgument2, TArgument3>
    {
        [JsonProperty]
        public string UrlTemplate { get; private set; }

        public UrlTemplate3(string urlTemplate)
        {
            UrlTemplate = urlTemplate;
        }

        public string CreateUrl(TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            return UrlTemplate.FormatWith(argument1, argument2, argument3);
        }

        public string CreateUrlUnsafe(object argument1, object argument2, object argument3)
        {
            return UrlTemplate.FormatWith(argument1, argument2, argument3);
        }
    }
}