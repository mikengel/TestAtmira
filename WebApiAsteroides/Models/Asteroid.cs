using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAsteroides.Models
{
    public class Asteroid
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("neo_reference_id")]
        public string NeoRreferenceId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("estimated_diameter")]
        public EstimatedDiameter EstimatedDiameter { get; set; }
        [JsonProperty("is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardousAsteroid { get; set; }
        [JsonProperty("close_approach_data")]
        public CloseApproachData[] CloseApproachData { get; set; }
    }
}
