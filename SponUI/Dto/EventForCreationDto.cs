using System;
using SponUI.Models;
using Newtonsoft.Json;

namespace SponUI.Dto
{
	public class EventForCreationDto
	{
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("photo")]
        public byte[] Photo { get; set; }

        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("activity")]
        public string Activity { get; set; }

        [JsonProperty("place")]
        public string Place { get; set; }

        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }
    }
}

