using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApiAsteroides.Data
{
    public class NasaConnection
    {
        private string _uri = $"https://api.nasa.gov";
        private string _url;
        private string _fechaDesde;
        private string _fechaHasta;
        private string _apiKey;
        private string _demoKey = "DEMO_KEY";
        // api_key = "zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb";
        public NasaConnection()
        {
        }

        public NasaConnection(string apiUrl)
        {
            _url = apiUrl;
        }

        public async Task<string> GetJsonAsteroides()
        {
            var result = string.Empty;
            var cliente = new HttpClient
            {
                BaseAddress = new Uri(_uri)
            };

            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            cliente.DefaultRequestHeaders.Add("User-Agent", "Awesome-Octocat-App");

            HttpResponseMessage response = await cliente.GetAsync(_url);

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }
    }
}
