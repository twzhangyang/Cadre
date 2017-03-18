using System;
using TypeLite;

namespace CadreManagement.Web.HyperMediaApi
{
    [TsClass]
    public class Link<TResource>
    {
        [Obsolete("For Serialization")]
        public Link()
        {
            
        }

        public Link(string uri)
        {
            Uri = uri;
        }

        public override string ToString()
        {
            return Uri;
        }

        public string Uri { get;  set; } 
      
    }
}