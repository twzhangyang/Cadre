using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace CadreManagement.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool None<T>(this IEnumerable<T> @this)
        {
            Contract.Requires(@this != null);

            return !@this.Any();
        }

        public static bool None<T>(this IEnumerable<T> @this, Func<T, bool> predicate)
        {
            Contract.Requires(@this != null);
            Contract.Requires(predicate != null);

            return !@this.Any(predicate);
        }
    }
}