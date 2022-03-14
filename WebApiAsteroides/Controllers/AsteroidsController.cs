using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiAsteroides.Models;

namespace WebApiAsteroides.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsteroidsController : ControllerBase
    {
        NasaManager _nasa = new NasaManager();
        string uri = $"https://api.nasa.gov";
        string url = $"https://api.nasa.gov/neo/rest/v1/feed?start_date={DateTime.Today.AddDays(-7):yyyy-MM-dd}&end_date={DateTime.Today:yyyy-MM-dd}&api_key=zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb";
                        
        // GET: api/Asteroids?planet=earth
        [HttpGet]
        public IEnumerable<ResultModel> GetAsteroid(string planet)
        {
            if (planet == null)
            {

            }
            _nasa.GetData(uri, url);

            bool IsOk = true;
            int cont = 0;
            while (IsOk)
            {
                Thread.Sleep(100);
                IsOk = _nasa.AsteroidesPotenciales == null;
                cont++;
                if (cont >= 1000)
                    IsOk = false;
            }

            return GetAsteroidsForPlanet(planet);
        }

        private IEnumerable<ResultModel> GetAsteroidsForPlanet(string planet)
        {
            IEnumerable<ResultModel> result = new List<ResultModel>();

            try
            {
                result = (from a in _nasa.AsteroidesPotenciales
                          where (DateTime.Today - Convert.ToDateTime(a.CloseApproachData[0].CloseApproachDate)).TotalDays < 7
                          where a.CloseApproachData[0].OrbitingBody.ToLower() == planet.ToLower()
                          select new ResultModel
                          {
                              Nombre = a.Name,
                              Diametro = a.EstimatedDiameter.Kilometers.EstimatedDiameterMid,
                              Velocidad= a.CloseApproachData[0].RelativeVelocity.KilometersPerHour,
                              Fecha = Convert.ToDateTime(a.CloseApproachData[0].CloseApproachDate),
                              Planeta = a.CloseApproachData[0].OrbitingBody
                          })
                          .OrderByDescending(x => x.Diametro)
                          .ThenByDescending(f => f.Fecha);
            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }
}
