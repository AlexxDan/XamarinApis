using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApis.Models
{
   public class Coche
    {
        [JsonProperty("idcoche")]
        public int IdCoche { get; set; }

        [JsonProperty("marca")]
        public String Marca { get; set; }

        [JsonProperty("modelo")]
        public String Modelo { get; set; }

        [JsonProperty("conductor")]
        public String Conductor { get; set; }

        [JsonProperty("imagen")]
        public String Imagen { get; set; }
    }
}
