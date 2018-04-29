using Newtonsoft.Json;

namespace AirplaneModeProof.Core.Models
{
	public class Superhero
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("photo")]
		public string Photo { get; set; }

		[JsonProperty("realName")]
		public string RealName { get; set; }

		[JsonProperty("height")]
		public string Height { get; set; }

		[JsonProperty("power")]
		public string Power { get; set; }

		[JsonProperty("abilities")]
		public string Abilities { get; set; }

		[JsonProperty("groups")]
		public string Groups { get; set; }
	}
}