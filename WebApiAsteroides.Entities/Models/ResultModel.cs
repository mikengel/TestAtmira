using System;

namespace WebApiAsteroides.Entities
{
    public class ResultModel
    {
        public string Nombre { get; set; }
        public float Diametro { get; set; }
        public string Velocidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Planeta { get; set; }
    }
}