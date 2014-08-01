using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesApi.Model
{
    public class Items
    {
        [JsonProperty(PropertyName = "items")]
        public List<Place> Places { get; set; }
    }
}
