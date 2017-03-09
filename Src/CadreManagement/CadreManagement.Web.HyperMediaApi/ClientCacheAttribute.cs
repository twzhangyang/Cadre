using System;
using System.Net.Http.Headers;
using System.Web.Http.Filters;

namespace CadreManagement.Web.HyperMediaApi
{
    public class ClientCacheAttribute : ActionFilterAttribute
    {
        private TimeSpan _maxAge = TimeSpan.Zero;

        public uint Seconds { get { return (uint)_maxAge.Seconds; } set { _maxAge = _maxAge.Add(TimeSpan.FromSeconds(value)); } }
        public uint Minutes { get { return (uint)_maxAge.Minutes; } set { _maxAge = _maxAge.Add(TimeSpan.FromMinutes(value)); } }
        public uint Hours { get { return (uint)_maxAge.Hours; } set { _maxAge = _maxAge.Add(TimeSpan.FromHours(value)); } }
        public uint Days { get { return (uint)_maxAge.Days; } set { _maxAge = _maxAge.Add(TimeSpan.FromDays(value)); } }

        public bool Public { get; set; }

        public ClientCacheAttribute()
        {
            Public = false;
        }

        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                if (_maxAge == TimeSpan.Zero)
                {
                    throw new InvalidOperationException("You must set the cache expiration time.");
                }

                context.Response.Headers.CacheControl = new CacheControlHeaderValue()
                {
                    Public = Public,
                    MaxAge = _maxAge
                };
            }

            base.OnActionExecuted(context);
        }
    }
}
