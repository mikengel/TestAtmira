using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiAsteroides.Entities
{
    interface IFloatMaxMin
    {
        [JsonProperty("estimated_diameter_min")]
        float DiametroMinimoEstimado { get; set; }
        [JsonProperty("estimated_diameter_max")]
        float DiametroMaximoEstimado { get; set; }
    }
}
