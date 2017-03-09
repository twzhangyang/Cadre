using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace CadreManagement.Web.HyperMediaApi
{
    public static class PropertyInfoHelper
    {
        private static readonly IDictionary<Type, IEnumerable<PropertyInfo>> TypeProperties = new ConcurrentDictionary<Type, IEnumerable<PropertyInfo>>();

        public static IEnumerable<PropertyInfo> GetPublicProperties(this Type type)
        {
            Contract.Requires(type != null);
            Contract.Ensures(Contract.Result<IEnumerable<PropertyInfo>>() != null);

            IEnumerable<PropertyInfo> properties;
            if (!TypeProperties.TryGetValue(type, out properties))
            {
                var newProperties = new List<PropertyInfo>();
                if (!type.IsPrimitive)
                {
                    newProperties.AddRange(type.GetProperties(BindingFlags.Instance | BindingFlags.Public));
                }
                TypeProperties[type] = properties = newProperties;
            }
            return properties;
        }
    }
}