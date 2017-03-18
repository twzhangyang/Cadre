using System;
using System.Web.Http;

namespace CadreManagement.Web.HyperMediaApi
{
    public class SubLinkNavigator<TResource, TParentResource> : LinkNavigator<TResource>
    {
        private readonly LinkNavigator<TParentResource> _parent;
        private readonly Func<TParentResource, Link<TResource>> _navigator;

        public SubLinkNavigator(LinkNavigator<TParentResource> parent, Func<TParentResource, Link<TResource>> navigator)
        {
            _parent = parent;
            _navigator = navigator;            
        }

        public override TResource Execute()
        {
            var parentResource = _parent.Execute();
            return FetchUri(_navigator(parentResource));
        }
    }
}