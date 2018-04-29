using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AirplaneModeProof.Core.Models;
using Newtonsoft.Json;

namespace AirplaneModeProof.Core.Services
{
	public class BackendService
	{
		private HttpClient _httpClient;

		private const string ApiBaseUrl = "http://airplanemodeproof-api.azurewebsites.net/api/";

		public BackendService()
		{
			_httpClient = new HttpClient
			{
				BaseAddress = new Uri(ApiBaseUrl)
			};
		}

		public async Task<IEnumerable<Superhero>> GetSuperheroes()
		{
			var resultHeroes = new List<Superhero>();

			var resultResponse = await _httpClient.GetAsync("superhero").ConfigureAwait(false);

			if (resultResponse.IsSuccessStatusCode)
			{
				var resultJson = await resultResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
				resultHeroes =
					await Task.Run(() => 
						JsonConvert.DeserializeObject<List<Superhero>>(resultJson)).ConfigureAwait(false);
			}

			return resultHeroes;
		}

		public async Task<IEnumerable<Comic>> GetComicsForSuperhero(int id)
		{
			var resultComics = new List<Comic>();

			var resultResponse = await _httpClient.GetAsync($"comic/{id}").ConfigureAwait(false);

			if (resultResponse.IsSuccessStatusCode)
			{
				var resultJson = await resultResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
				resultComics =
					await Task.Run(() =>
						JsonConvert.DeserializeObject<List<Comic>>(resultJson)).ConfigureAwait(false);
			}

			return resultComics;
		}
	}
}