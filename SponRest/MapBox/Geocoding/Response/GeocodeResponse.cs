using System;
using Newtonsoft.Json;

namespace SponRest.MapBox.Geocoding.Response
{
	public class GeocodeResponse
	{
        [JsonProperty("type", Order = 0)]
        public string Type { get; set; }

        [JsonProperty("query", Order = 1)]
        public List<double> Query { get; set; }

        [JsonProperty("features", Order = 2)]
        public List<Feature> Features { get; set; }

        [JsonProperty("attribution", Order = 3)]
        public string Attribution { get; set; }
    }
}

