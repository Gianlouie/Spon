using System;
using Newtonsoft.Json;
namespace SponRest.MapBox.Searchbox.Response
{
	public class SearchboxResponse
	{
		[JsonProperty("suggestions")]
		public List<Suggestion> Suggestions { get; set; }

        [JsonProperty("attribution")]
        public string Attribution { get; set; }
    }
}

