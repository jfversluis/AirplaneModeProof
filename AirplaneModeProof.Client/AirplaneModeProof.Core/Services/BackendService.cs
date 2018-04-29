using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AirplaneModeProof.Core.Interfaces;
using AirplaneModeProof.Core.Models;
using Refit;

namespace AirplaneModeProof.Core.Services
{
	public class BackendService
	{
		private readonly IBackendService _restService;

		private const string ApiBaseUrl = "http://airplanemodeproof-api.azurewebsites.net/api/";

		public BackendService()
		{
			_restService = RestService.For<IBackendService>(ApiBaseUrl); 
		}

		public async Task<IEnumerable<Superhero>> GetSuperheroes()
		{
			return await _restService.GetSuperheroes();
		}

		public async Task<IEnumerable<Comic>> GetComicsForSuperhero(int id)
		{
			try
			{
				return await _restService.GetComicsForSuperhero(id);
			}
			catch (ApiException ex)
			{
				Console.WriteLine($"Something bad happened! Status code: {ex.StatusCode}");
				return new List<Comic>();
			}
		}
	}
}