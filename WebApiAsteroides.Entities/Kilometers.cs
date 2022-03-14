using Newtonsoft.Json;

namespace WebApiAsteroides.Entities
{
    public class Kilometers
    {
        [JsonProperty("estimated_diameter_min")]
        public float EstimatedDiameterMin { get; set; }
        [JsonProperty("estimated_diameter_max")]
        public float EstimatedDiameterMax { get; set; }
        public float EstimatedDiameterMid
        {
            get
            {
                return (EstimatedDiameterMin + EstimatedDiameterMax) / 2.0f;
            }
        }
    }
}