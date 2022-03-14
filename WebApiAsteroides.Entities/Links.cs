using Newtonsoft.Json;

namespace WebApiAsteroides.Entities
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
}
