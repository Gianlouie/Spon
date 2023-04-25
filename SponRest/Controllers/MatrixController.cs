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

		[HttpGet]
		public async Task<ActionResult> GetMatrix([FromQuery]MatrixRequest matrixRequest)
		{
			try
			{
				var response = await _matrixClient.GetMatrix(matrixRequest.A, matrixRequest.B);

				return Ok(response);
			}
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
	}
}

