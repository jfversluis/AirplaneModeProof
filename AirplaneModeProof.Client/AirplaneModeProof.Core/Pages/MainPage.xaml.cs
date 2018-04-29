using AirplaneModeProof.Core.PageModels;
using Xamarin.Forms;
using System;
using AirplaneModeProof.Core.Models;

namespace AirplaneModeProof.Core.Pages
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			BindingContext = new MainPageModel();
		}

		public void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
				return;
			
			Navigation.PushAsync(new SuperheroDetailsPage
			{
				BindingContext = new SuperheroDetailsPageModel(e.SelectedItem as Superhero)
			});

			SuperheroList.SelectedItem = null;
		}
	}
}