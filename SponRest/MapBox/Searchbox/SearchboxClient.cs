using System;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using SponRest.MapBox.Geocoding.Response;
using SponRest.MapBox.Matrix;
using SponRest.MapBox.Searchbox.Response;
using SponRest.Models;

namespace SponRest.MapBox.Searchbox
{
	public class SearchboxClient
	{
        private readonly IConfiguration _configuration;
        private readonly string _accessToken;
        private readonly string _baseUrl;

        public SearchboxClient(IConfiguration configuration)
        {
            _configuration = configuration;
            _accessToken = _configuration.GetSection("MapBox")["AccessToken"];
            _baseUrl = _configuration.GetSection("MapBox")["SearchboxBaseUrl"];
        }

        public async Task<SearchboxResponse> GetSearchboxSuggestions(string searchText, Guid sessionToken)
        {
            var options = new RestClientOptions(_baseUrl);

            var client = new RestClient(options);

            var request = new RestRequest("suggest?q=" + searchText + "&limit=10&session_token=" + sessionToken + "&country=US" + "&access_token=" + _accessToken);

            var response = await client.GetAsync(request);

            var dsresponse = JsonConvert.DeserializeObject<SearchboxResponse>(response.Content);

            return dsresponse;
        }
    }
}

