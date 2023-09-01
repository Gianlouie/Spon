using System;
using Newtonsoft.Json;
namespace SponUI.Models
{ 
    public class Suggestion
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("name_preferred")]
		public string NamePreferred { get; set;}

		[JsonProperty("mapbox_id")]
		public string MapboxId { get; set; }

		[JsonProperty("feature_type")]
		public string FeatureType { get; set; }

		[JsonProperty("address")]
		public string Address { get; set; }

		[JsonProperty("full_address")]
		public string FullAddress { get; set; }

        [JsonProperty("context")]
        public Dictionary<string, object> Context { get; set; }
    }
}

