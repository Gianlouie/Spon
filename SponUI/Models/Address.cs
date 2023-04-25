using System;
using Newtonsoft.Json;
namespace SponUI.Models
{
	public class Address
	{
        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}

