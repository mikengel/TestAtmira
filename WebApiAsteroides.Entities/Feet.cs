using Newtonsoft.Json;

namespace WebApiAsteroides.Entities
{
    public class Feet : IFloatMaxMin
    {
        public float DiametroMinimoEstimado { get; set; }
        public float DiametroMaximoEstimado { get; set; }
    }
}