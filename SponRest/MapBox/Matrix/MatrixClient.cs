using System;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using SponRest.Enums;
using SponRest.Models;

namespace SponRest.MapBox.Matrix
{
	public class MatrixClient
	{
        private readonly IConfiguration _configuration;
        private readonly string _accessToken;
        private readonly string _baseUrl;

        public MatrixClient(IConfiguration configuration)
        {
            _configuration = configuration;
            _accessToken = _configuration.GetSection("MapBox")["AccessToken"];
            _baseUrl = _configuration.GetSection("MapBox")["MatrixBaseUrl"];
        }

        public async Task<MatrixResponse> GetMatrix(List<Coordinates> coordinates)
		{
			StringBuilder coordinateStr = new StringBuilder();

			for(int i = 0; i < coordinates.Count; i++)
			{
				coordinateStr.Append(coordinates[i].Longitude + "," + coordinates[i].Latitude);

				if (i != coordinates.Count - 1)
				{
					coordinateStr.Append(';');
				}
			}

			var options = new RestClientOptions(_baseUrl);

			var client = new RestClient(options);

			var request = new RestRequest(MatrixProfile.Driving+ "/" + coordinateStr + "?access_token=" + _accessToken + "&annotations=distance");

			var response = await client.GetAsync(request);

			var dsresponse = JsonConvert.DeserializeObject<MatrixResponse>(response.Content);

			return dsresponse;
		}
	}
}

