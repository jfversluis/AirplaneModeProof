using System.Windows.Input;
using AirplaneModeProof.Core.Models;

namespace AirplaneModeProof.Core.PageModels
{
	public class SuperheroDetailsPageModel : BasePageModel
	{
		public Superhero Superhero { get; }

		public SuperheroDetailsPageModel(Superhero superhero)
		{
			Superhero = superhero;
		}
	}
}