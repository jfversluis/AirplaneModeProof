using Acr.UserDialogs;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using AirplaneModeProof.Core.Models;
using AirplaneModeProof.Core.Services;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace AirplaneModeProof.Core.PageModels
{
	public class SuperheroComicsPageModel : BasePageModel
	{
		private BackendService _backendService = new BackendService();
		private ICommand _refreshListCommand;

		public Superhero Superhero { get; }

		public ObservableCollection<Comic> Comics { get; set; }
			= new ObservableCollection<Comic>();

		public ICommand RefreshListCommand
		{
			get
			{
				return _refreshListCommand ?? (_refreshListCommand = new Command(async () => await RefreshList()));
			}
		}

		public SuperheroComicsPageModel(Superhero superhero)
		{
			Superhero = superhero;
			RefreshListCommand.Execute(null);
		}

		private async Task RefreshList()
		{
			IsLoading = true;

			if (!CrossConnectivity.Current.IsConnected)
			{
				await UserDialogs.Instance
					.AlertAsync("No internet connection available", "Nope, sorry!", "OK");
			}

			await LoadSuperheroes();

			IsLoading = false;
		}

		private async Task LoadSuperheroes()
		{
			Comics.Clear();

			var comics = await _backendService.GetComicsForSuperhero(Superhero.Id);

			foreach (var comic in comics)
			{
				Comics.Add(comic);
			}
		}
	}
}