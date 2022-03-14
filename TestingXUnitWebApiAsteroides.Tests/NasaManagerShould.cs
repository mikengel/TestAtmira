using System.Threading;
using WebApiAsteroides;
using WebApiAsteroides.Manager;
using Xunit;

namespace TestingXUnitWebApiAsteroides.Tests
{
    public class NasaManagerShould
    {
        [Fact]
        public void GettingGetAsteroidsForPlanet()
        {
            var url = "https://api.nasa.gov/neo/rest/v1/feed?start_date=2020-09-09&end_date=2020-09-16&api_key=zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb";
            var nasa = new NasaManager(url);

            nasa.GetAsteroidsForPlanet("earth");
                        
            Assert.True(nasa.AsteroidesPotenciales != null, $"Nasa.GetData() ha devuelto nulo!");
        }
    }
}
