using System.Threading;
using WebApiAsteroides;
using Xunit;

namespace TestingXUnitWebApiAsteroides.Tests
{
    public class NasaManagerShould
    {
        [Fact]
        public void GettingGetData()
        {
            var nasa = new NasaManager();
            var uri = $"https://api.nasa.gov";
            var url = "https://api.nasa.gov/neo/rest/v1/feed?start_date=2020-09-09&end_date=2020-09-16&api_key=zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb";

            nasa.GetData(uri, url);

            bool IsOk = true;
            int cont = 0;
            while (IsOk)
            {
                Thread.Sleep(100);
                IsOk = nasa.AsteroidesPotenciales == null;
                cont++;
                if (cont >= 1000)
                    IsOk = false;
            }

            Assert.True(nasa.AsteroidesPotenciales != null, $"Nasa.GetData() ha devuelto nulo!");
        }
    }
}
