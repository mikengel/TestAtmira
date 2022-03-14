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
            var filtros = url.Split('?')[1];
            var parametros = filtros.Split('&');
            var fechaDesde = Convert.ToDateTime(parametros[0].Split('=')[1]);
            var fechaHasta = Convert.ToDateTime(parametros[1].Split('=')[1]);
            var dias = (fechaHasta - fechaDesde).TotalDays;

            var cliente = new HttpClient
            {
                BaseAddress = new Uri(uri)
            };

            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            cliente.DefaultRequestHeaders.Add("User-Agent", "Awesome-Octocat-App");

            HttpResponseMessage response = await cliente.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                
                var jsonObj = JObject.Parse(json);
                var objCercanos = (JObject)jsonObj["near_earth_objects"];

                for (var i = 0; i <= dias; i++)
                {
                    var jsonArray = (JArray)objCercanos[$"{fechaDesde.AddDays(i):yyyy-MM-dd}"];

                    foreach (JObject item in jsonArray)
                    {
                        var asteroid = new Asteroid();
                        asteroid = item.ToObject<Asteroid>();

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
