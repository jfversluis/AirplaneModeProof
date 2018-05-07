using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AirplaneModeProof.Core.Interfaces;
using AirplaneModeProof.Core.Models;
using Akavache;
using Plugin.Connectivity;
using Polly;
using Refit;

namespace AirplaneModeProof.Core.Services
{
	public class BackendService
	{
		private readonly HttpClient _customHttpClient;
		private readonly EtagHttpClientHandler _customHttpClientHandler;
		private readonly IBackendService _restService;
		private readonly IBlobCache _cache = BlobCache.UserAccount;

		private const string ApiBaseUrl = "http://airplanemodeproof-api.azurewebsites.net/api/";

		public BackendService()
		{
			_customHttpClientHandler = new EtagHttpClientHandler();
			_customHttpClient = new HttpClient(_customHttpClientHandler)
			{
				BaseAddress = new Uri(ApiBaseUrl)
			};

			_restService = RestService.For<IBackendService>(_customHttpClient);
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
			return await Policy
					.Handle<ApiException>(ex => ex.StatusCode != HttpStatusCode.NotFound && ex.StatusCode != HttpStatusCode.NotModified)
					.WaitAndRetryAsync
					(
						retryCount: 3,
						sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
						onRetry: (ex, time) =>
						{
							Console.WriteLine($"Something went wrong: {ex.Message}, retrying...");
						}
					)
					.ExecuteAsync(async () =>
					{
						 Console.WriteLine($"Trying to fetch remote data...");
						 return await _restService.GetComicsForSuperhero(id);
					});
		}
	}
}