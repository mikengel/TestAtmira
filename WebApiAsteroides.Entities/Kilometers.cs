using Newtonsoft.Json;

namespace WebApiAsteroides.Entities
{
    public class Kilometers : IFloatMaxMin
    {
        public float DiametroMinimoEstimado { get; set; }
        public float DiametroMaximoEstimado { get; set; }
    }
}