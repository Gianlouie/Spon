using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SponRest.MapBox.Matrix;
using SponRest.Models;

namespace SponRest.Controllers
{
	[ApiController]
	[Route("api/Matrix")]
	public class MatrixController : Controller
	{
		private readonly MatrixClient _matrixClient;

		public MatrixController(MatrixClient matrixClient)
		{
			_matrixClient = matrixClient;
		}

		[HttpPost]
		public async Task<ActionResult> GetMatrix(List<Coordinates> coordinates)
		{
			try
			{
                if (coordinates.Count > 25)
                {
                    throw new ArgumentOutOfRangeException(paramName: "coordinates", message: "Cannot process more than 25 coordinates.");
                }

                var response = await _matrixClient.GetMatrix(coordinates);

				return Ok(response);
			}
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
	}
}

