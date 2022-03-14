using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApiAsteroides.Entities.Helps
{
    public static class Reflection
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public static T Cast<T>(this object objeto)
        {
            if (objeto == null)
                return default(T);

            var json = JsonConvert.SerializeObject(objeto, Formatting.Indented,
                new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                });
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
