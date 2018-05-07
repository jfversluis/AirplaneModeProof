using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Akavache;
using System.Reactive.Linq;
using Microsoft.AspNetCore.WebUtilities;

namespace AirplaneModeProof.Core
{
	public class EtagHttpClientHandler : HttpClientHandler
	{
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			// Everything before the base call is the request
			try
			{
				// See if we have a ETag for this endpoint and add it to the request
				var etag = await BlobCache.LocalMachine.GetObject<string>(request.RequestUri.ToString());

				if (!string.IsNullOrWhiteSpace(etag))
				{
					request.Headers.IfNoneMatch.Clear();
					request.Headers.IfNoneMatch.Add(new EntityTagHeaderValue(etag));
				}
			}
			catch
			{
				// Intentionally left blank, Akavache throws an exception id the key is not found
			}

			// Do the call
			var responseMessage = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

			// Here we can handle the response
			if (responseMessage.IsSuccessStatusCode)
			{
				// If a ETag is provided with the response, cache it for future requests
				if (!string.IsNullOrWhiteSpace(responseMessage.Headers.ETag?.Tag))
					await BlobCache.LocalMachine.InsertObject<string>(responseMessage.RequestMessage.RequestUri.ToString(), responseMessage.Headers.ETag?.Tag);
			}

			return responseMessage;
		}

		private static string CalculateChecksum(byte[] ms)
		{
			string checksum = "";

			using (var algo = SHA1.Create())
			{
				byte[] bytes = algo.ComputeHash(ms);
				// Maybe not refence AspNetCore libraries here...
				checksum = $"\"{WebEncoders.Base64UrlEncode(bytes)}\"";
			}

			return checksum;
		}
	}
}