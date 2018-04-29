using Newtonsoft.Json;

namespace AirplaneModeProof.Api.Models
{
	public class Comic
	{
		[JsonProperty("superheroId")]
		public int SuperheroId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}