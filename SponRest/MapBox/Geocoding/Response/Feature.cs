using System;
using Newtonsoft.Json;

namespace SponRest.MapBox.Geocoding.Response
{
	public class Feature
	{
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("place_name")]
        public string PlaceName { get; set; }

        [JsonProperty("relevance")]
        public double Relevance { get; set; }

        [JsonProperty("properties")]
        public Dictionary<string, object> Properties { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("context")]
        public List<Dictionary<string, string>> Context { get; set; }
    }
}

