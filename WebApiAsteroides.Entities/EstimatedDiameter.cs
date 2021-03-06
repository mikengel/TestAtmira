using Newtonsoft.Json;

namespace WebApiAsteroides.Entities
{
    public class EstimatedDiameter
    {
        [JsonProperty("kilometers")]
        public Kilometers Kilometers { get; set; }
        [JsonProperty("meters")]
        public Meters Meters { get; set; }
        [JsonProperty("miles")]
        public Miles Miles { get; set; }
        [JsonProperty("feet")]
        public Feet Feet { get; set; }
    }
}