using System;
using Newtonsoft.Json;
using SponUI.Models;

namespace SponUI.Models
{
	public class SearchboxResponse
	{
		[JsonProperty("suggestions")]
		public List<Suggestion> Suggestions { get; set; }

        [JsonProperty("attribution")]
        public string Attribution { get; set; }
    }
}

