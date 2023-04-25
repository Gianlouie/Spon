using System;
using Newtonsoft.Json;
namespace SponRest.MapBox.Matrix
{
	public class MatrixResponse
	{
		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("distances")]
		public List<List<float>> Distances { get; set; }
	}
}

