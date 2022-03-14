using Newtonsoft.Json;

namespace WebApiAsteroides.Entities
{
    public class Meters : IFloatMaxMin
    {
        public float DiametroMinimoEstimado { get; set; }
        public float DiametroMaximoEstimado { get; set; }
    }
}