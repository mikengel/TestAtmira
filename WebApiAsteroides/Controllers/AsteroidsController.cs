using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiAsteroides.Entities;
using WebApiAsteroides.Manager;

namespace WebApiAsteroides.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsteroidsController : ControllerBase
    {
        string _url = $"https://api.nasa.gov/neo/rest/v1/feed?start_date={DateTime.Today.AddDays(-7):yyyy-MM-dd}&end_date={DateTime.Today:yyyy-MM-dd}&api_key=zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb";
                        
        // GET: api/Asteroids?planet=earth
        [HttpGet]
        public ActionResult<IEnumerable<ResultModel>> GetAsteroid(string planet)
        {
            if (planet != null)
            {
                var nasa = new NasaManager(_url);

                var result = new ActionResult<IEnumerable<ResultModel>>(nasa.GetAsteroidsForPlanet(planet));
                return result;                
            }

            return NoContent();
        }        
    }
}
