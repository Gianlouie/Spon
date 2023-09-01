using System;
using Newtonsoft.Json;

namespace SponUI.Models
{
	public class Coordinates
	{
        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }
    }
}

