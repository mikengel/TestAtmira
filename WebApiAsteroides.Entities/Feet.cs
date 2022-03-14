using Newtonsoft.Json;

namespace WebApiAsteroides.Entities
{
    public class Feet
    {
        [JsonProperty("estimated_diameter_min")]
        public float EstimatedDiameterMin { get; set; }
        [JsonProperty("estimated_diameter_max")]
        public float EstimatedDiameterMax { get; set; }
    }
}