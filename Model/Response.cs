using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesApi.Model
{
    public class Response
    {
        [JsonProperty(PropertyName = "results")]
        public Items Results { get; set; }
    }
}
