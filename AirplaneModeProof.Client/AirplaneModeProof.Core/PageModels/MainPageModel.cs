using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using AirplaneModeProof.Core.Models;
using AirplaneModeProof.Core.Services;
using Xamarin.Forms;

namespace AirplaneModeProof.Core.PageModels
{
	public class MainPageModel : BasePageModel
	{
		private BackendService _backendService = new BackendService();
		private ICommand _refreshListCommand;

		public ObservableCollection<Superhero> Superheroes { get; set; }
			= new ObservableCollection<Superhero>();

		public ICommand RefreshListCommand
		{
			get
			{
				return _refreshListCommand ?? (_refreshListCommand = new Command(async () => await RefreshList()));
			}
		}

		public MainPageModel()
		{
			RefreshListCommand.Execute(null);
		}

		private async Task RefreshList()
		{
			IsLoading = true;

			await LoadSuperheroes();

			IsLoading = false;
		}

		private async Task LoadSuperheroes()
		{
			Superheroes.Clear();

			var heroes = await _backendService.GetSuperheroes();

			foreach(var hero in heroes)
			{
				Superheroes.Add(hero);
			}
		}
	}
}