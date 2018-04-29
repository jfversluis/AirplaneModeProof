using System.Collections.Generic;
using System.Threading.Tasks;
using AirplaneModeProof.Core.Models;
using Refit;

namespace AirplaneModeProof.Core.Interfaces
{
	public interface IBackendService
	{
		[Get("/superhero")]
		Task<IEnumerable<Superhero>> GetSuperheroes();

		[Get("/comic/{superheroId}")]
		Task<IEnumerable<Comic>> GetComicsForSuperhero(int superheroId);
	}
}