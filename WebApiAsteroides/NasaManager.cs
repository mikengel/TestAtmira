using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApiAsteroides.Help;
using WebApiAsteroides.Models;

namespace WebApiAsteroides
{
    public class NasaManager
    {
        public IList<Asteroid> AsteroidesPotenciales;
        public async void GetData(string uri, string url)
        {
            var queryString = url.Split('?')[1];
            var queryStrArray = queryString.Split('&');
            var fechaDesde = Convert.ToDateTime(queryStrArray[0].Split('=')[1]);
            var fechaHasta = Convert.ToDateTime(queryStrArray[1].Split('=')[1]);
            var dias = (fechaHasta - fechaDesde).TotalDays;
            var client = new HttpClient
            {
                BaseAddress = new Uri(uri)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Awesome-Octocat-App");

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                
                JObject root = JObject.Parse(json);
                JObject near = (JObject)root["near_earth_objects"];

                for (var i = 0; i <= dias; i++)
                {
                    JArray jArray = (JArray)near[$"{fechaDesde.AddDays(i):yyyy-MM-dd}"];

                    foreach (JObject jObject in jArray)
                    {
                        var asteroid = new Asteroid();
                        asteroid = jObject.ToObject<Asteroid>();

                        if (asteroid.IsPotentiallyHazardousAsteroid)
                        {
                            if (AsteroidesPotenciales == null)
                                AsteroidesPotenciales = new List<Asteroid>();
                            AsteroidesPotenciales.Add(asteroid);
                        }
                    }
                }                                
            }
        }
    }
}
