using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using AirplaneModeProof.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneModeProof.Api.Controllers
{
	[Route("api/[controller]")]
	public class ComicController : Controller
	{
		private Random _random = new Random();

		// GET api/comic/3
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			if (_random.Next(2) % 2 == 0 && id == 2)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError);
			}

			if (FakeDatabase.Comics.Any(c => c.SuperheroId == id))
			{
				return Ok(FakeDatabase.Comics.Where(c => c.SuperheroId == id));
			}

			var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
			return NotFound(id);
		}
	}
}