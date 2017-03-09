﻿using TypeLite;

namespace CadreManagement.Web.HyperMediaApi
{
    [TsClass]
    public class Link<TResource>
    {
        public Link(string uri)
        {
            Uri = uri;
        }

        override public string ToString()
        {
            return Uri;
        }

        public string Uri { get; private set; } 
    }
}