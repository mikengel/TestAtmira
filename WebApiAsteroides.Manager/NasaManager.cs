using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiAsteroides.Data;
using WebApiAsteroides.Entities;

namespace WebApiAsteroides.Manager
{
    public class NasaManager
    {
        private string _url;
        public IList<Asteroid> AsteroidesPotenciales;
        public NasaManager()
        {
            _url = $"https://api.nasa.gov/neo/rest/v1/feed?start_date={DateTime.Today.AddDays(-7):yyyy-MM-dd}&end_date={DateTime.Today:yyyy-MM-dd}&api_key=zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb"; ;
        }

        public NasaManager(string url)
        {
            _url = url;
        }

        private async void GetAsteroids()
        {
            var filtros = _url.Split('?')[1];
            var parametros = filtros.Split('&');
            var fechaDesde = Convert.ToDateTime(parametros[0].Split('=')[1]);
            var fechaHasta = Convert.ToDateTime(parametros[1].Split('=')[1]);
            var dias = (fechaHasta - fechaDesde).TotalDays;

            var conn = new NasaConnection(_url);
            var jsonData = await conn.GetJsonAsteroides();

            if (!string.IsNullOrEmpty(jsonData))
            {
                var jsonObj = JObject.Parse(jsonData);
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

        public IEnumerable<ResultModel> GetAsteroidsForPlanet(string planet)
        {
            IEnumerable<ResultModel> result = new List<ResultModel>();

            try
            {
                GetAsteroids();

                bool IsOk = true;
                int cont = 0;
                while (IsOk)
                {
                    Thread.Sleep(100);
                    IsOk = AsteroidesPotenciales == null;
                    cont++;
                    if (cont >= 1000)
                        IsOk = false;
                }
                result = (from a in AsteroidesPotenciales
                          where (DateTime.Today - Convert.ToDateTime(a.CloseApproachData[0].CloseApproachDate)).TotalDays < 7
                          where a.CloseApproachData[0].OrbitingBody.ToLower() == planet.ToLower()
                          select new ResultModel
                          {
                              Nombre = a.Name,
                              Diametro = (a.EstimatedDiameter.Kilometers.DiametroMinimoEstimado
                              + a.EstimatedDiameter.Kilometers.DiametroMaximoEstimado) / 2.0f,
                              Velocidad = a.CloseApproachData[0].RelativeVelocity.KilometersPerHour,
                              Fecha = Convert.ToDateTime(a.CloseApproachData[0].CloseApproachDate),
                              Planeta = a.CloseApproachData[0].OrbitingBody
                          })
                          .OrderByDescending(x => x.Diametro)
                          .ThenByDescending(f => f.Fecha)
                          .Take(3);
            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }
}
