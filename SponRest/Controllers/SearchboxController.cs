using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SponRest.MapBox.Matrix;
using SponRest.Models;
using SponRest.MapBox.Searchbox;

namespace SponRest.Controllers
{
    [ApiController]
    [Route("api/Searchbox")]
    public class SearchboxController : Controller
	{
		private readonly SearchboxClient _searchboxClient;

		public SearchboxController(SearchboxClient searchboxClient)
		{
			_searchboxClient = searchboxClient;
		}

		[HttpGet]
		public async Task<ActionResult> GetSearchBoxSuggestions(string searchText)
		{
			try
			{
				var response = await _searchboxClient.GetSearchboxSuggestions(searchText, Guid.NewGuid());

				return Ok(response);
			}
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
	}
}

