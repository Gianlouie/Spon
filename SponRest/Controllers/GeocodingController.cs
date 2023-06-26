using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SponRest.MapBox.Geocoding;
using SponRest.MapBox.Geocoding.Request;
using SponRest.MapBox.Matrix;
using SponRest.Models;

namespace SponRest.Controllers
{
    [ApiController]
    [Route("api/Geocoding")]
    public class GeocodingController : Controller
	{
		private readonly GeocodingClient _geocodingClient;

		public GeocodingController(GeocodingClient geocodingClient)
		{
			_geocodingClient = geocodingClient;
		}

		[HttpGet]
		public async Task<ActionResult> GetReverseGeoCoding([FromQuery]GeocodingRequest geocodingRequest)
		{
			try
			{
				var response = await _geocodingClient.GetReverseGeocode(geocodingRequest.A);

				return Ok(response);
			}
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
	}
}

