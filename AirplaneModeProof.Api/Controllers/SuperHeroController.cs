using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AirplaneModeProof.Api.Data;
using AirplaneModeProof.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneModeProof.Api.Controllers
{
	[Route("api/[controller]")]
	public class SuperHeroController : Controller
	{
		// GET api/superhero
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(FakeDatabase.Superheroes);
		}

		// GET api/superhero/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			if (FakeDatabase.Superheroes.Any(c => c.Id == id))
			{
				return Ok(FakeDatabase.Superheroes.FirstOrDefault(c => c.Id == id));
			}

			var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
			return NotFound(id);
		}
	}
}