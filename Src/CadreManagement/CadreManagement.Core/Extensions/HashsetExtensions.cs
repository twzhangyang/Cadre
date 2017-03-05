using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CadreManagement.Core.Extensions
{
    public static class HashsetExtensions
    {
        public static List<TModel> ToModel<TModel>(this HashSet<string> hashSet)
        {
            var list = hashSet.Select(JsonConvert.DeserializeObject<TModel>).ToList();
            return list;
        }
    }
}