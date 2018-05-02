using System;
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

			LoadSuperheroes();

			IsLoading = false;
		}

		private void LoadSuperheroes()
		{
			_backendService.GetComicsForSuperhero(Superhero.Id).Subscribe((comics) =>
			{
				Device.BeginInvokeOnMainThread(() =>
				{
					Comics.Clear();

					foreach (var comic in comics)
					{
						Comics.Add(comic);
					}
				});
			}, async (ex) =>
			{
				await UserDialogs.Instance
					.AlertAsync("Something bad happened", "Nope, sorry!", "OK");
			});
		}
	}
}