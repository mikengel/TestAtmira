using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAsteroides.Models
{
    public class Links
    {
        [JsonProperty("self")]
        public string Self { get; set; }
        [JsonProperty("prev")]
        public string Prev { get; set; }
        [JsonProperty("next")]
        public string Next { get; set; }
    }

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

    public class Meters
    {
        [JsonProperty("estimated_diameter_min")]
        public float EstimatedDiameterMin { get; set; }
        [JsonProperty("estimated_diameter_max")]
        public float EstimatedDiameterMax { get; set; }
    }

    public class Miles
    {
        [JsonProperty("estimated_diameter_min")]
        public float EstimatedDiameterMin { get; set; }
        [JsonProperty("estimated_diameter_max")]
        public float EstimatedDiameterMax { get; set; }
    }

    public class Feet
    {
        [JsonProperty("estimated_diameter_min")]
        public float EstimatedDiameterMin { get; set; }
        [JsonProperty("estimated_diameter_max")]
        public float EstimatedDiameterMax { get; set; }
    }

    public class CloseApproachData
    {
        [JsonProperty("close_approach_date")]
        public string CloseApproachDate { get; set; }
        [JsonProperty("close_approach_date_full")]
        public string CloseApproachDateFull { get; set; }
        [JsonProperty("epoch_date_close_approach")]
        public long EpochDateCloseApproach { get; set; }
        [JsonProperty("relative_velocity")]
        public RelativeVelocity RelativeVelocity { get; set; }
        [JsonProperty("miss_distance")]
        public MissDistance MissDistance { get; set; }
        [JsonProperty("orbiting_body")]
        public string OrbitingBody { get; set; }
    }

    public class RelativeVelocity
    {
        [JsonProperty("kilometers_per_second")]
        public string KilometersPerSecond { get; set; }
        [JsonProperty("kilometers_per_hour")]
        public string KilometersPerHour { get; set; }
        [JsonProperty("miles_per_hour")]
        public string MilesPerHour { get; set; }
    }

    public class MissDistance
    {
        [JsonProperty("astronomical")]
        public string Astronomical { get; set; }
        [JsonProperty("lunar")]
        public string Lunar { get; set; }
        [JsonProperty("kilometers")]
        public string Kilometers { get; set; }
        [JsonProperty("miles")]
        public string Miles { get; set; }
    }

}
