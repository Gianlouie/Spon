using System;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
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

		public async Task<string> GetMatrix(Coordinates A, Coordinates B)
		{
			StringBuilder coordinateStr = new StringBuilder();

			coordinateStr.Append(A.Longitude + "," + A.Latitude + ";" + B.Longitude + "," + B.Latitude);

			var options = new RestClientOptions(_baseUrl);

			var client = new RestClient(options);

			var request = new RestRequest(MatrixProfile.Driving+ "/" + coordinateStr + "?access_token=" + _accessToken + "&annotations=distance");

			var response = await client.GetAsync(request);

			return response.Content;
		}
	}
}

