using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirplaneModeProof.Core.Interfaces;
using AirplaneModeProof.Core.Models;
using Akavache;
using Plugin.Connectivity;
using Refit;

namespace AirplaneModeProof.Core.Services
{
	public class BackendService
	{
		private readonly IBackendService _restService;
		private readonly IBlobCache _cache = BlobCache.UserAccount;

		private const string ApiBaseUrl = "http://airplanemodeproof-api.azurewebsites.net/api/";

		public BackendService()
		{
			_restService = RestService.For<IBackendService>(ApiBaseUrl); 
		}

		public IObservable<IEnumerable<Superhero>> GetSuperheroes()
		{
			
			return _cache.GetAndFetchLatest("superheroes",
				async () => await _restService.GetSuperheroes(), (offset) =>
			{
				if (!CrossConnectivity.Current.IsConnected)
					return false;
				
				// return a boolean to indicate the cache is invalidated
				return (DateTimeOffset.Now - offset).Hours > 24;
			});
		}

		public IObservable<IEnumerable<Comic>> GetComicsForSuperhero(int id)
		{
			return _cache.GetAndFetchLatest($"comicsforhero-{id}",
				async () => await GetComicsForSuperheroRemote(id), (offset) =>
				{
					// return a boolean to indicate the cache is invalidated
					return (DateTimeOffset.Now - offset).Seconds > 5;
				});
		}

		private async Task<IEnumerable<Comic>> GetComicsForSuperheroRemote(int id)
		{
			try
			{
				return await _restService.GetComicsForSuperhero(id);
			}
			catch (ApiException ex)
			{
				Console.WriteLine($"Something bad happened! Status code: {ex.StatusCode}");
				throw;
			}
		}
	}
}