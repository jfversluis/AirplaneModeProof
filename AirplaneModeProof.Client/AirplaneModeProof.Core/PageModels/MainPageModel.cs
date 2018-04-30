using System;
using System.Collections.ObjectModel;
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
				return _refreshListCommand ?? (_refreshListCommand = new Command(() => RefreshList()));
			}
		}

		public MainPageModel()
		{
			RefreshListCommand.Execute(null);
		}

		private void RefreshList()
		{
			IsLoading = true;

			LoadSuperheroes();

			IsLoading = false;
		}

		private void LoadSuperheroes()
		{
			_backendService.GetSuperheroes().Subscribe((superheroes) =>
			{
				Superheroes.Clear();

				foreach (var hero in superheroes)
				{
					Superheroes.Add(hero);
				}
			});
		}
	}
}