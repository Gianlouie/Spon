using System;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using SponRest.MapBox.Geocoding.Response;
using SponRest.MapBox.Matrix;
using SponRest.Models;

namespace SponRest.MapBox.Geocoding
{
	public class GeocodingClient
	{
        private readonly IConfiguration _configuration;
        private readonly string _accessToken;
        private readonly string _baseUrl;

        public GeocodingClient(IConfiguration configuration)
		{
            _configuration = configuration;
            _accessToken = _configuration.GetSection("MapBox")["AccessToken"];
            _baseUrl = _configuration.GetSection("MapBox")["GeocodingBaseUrl"];
        }

        public async Task<GeocodeResponse> GetReverseGeocode(Coordinates A)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(A.Longitude + "," + A.Latitude);

            var options = new RestClientOptions(_baseUrl);

            var client = new RestClient(options);

            var request = new RestRequest("mapbox.places/" + sb +".json" + "?limit=1" + "&types=region" + "&access_token=" + _accessToken);

            var response = await client.GetAsync(request);

            var dsresponse = JsonConvert.DeserializeObject<GeocodeResponse>(response.Content);

            return dsresponse;
        }
	}
}

