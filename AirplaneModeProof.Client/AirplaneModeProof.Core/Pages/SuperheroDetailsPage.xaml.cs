using Xamarin.Forms;
using System;
using AirplaneModeProof.Core.PageModels;

namespace AirplaneModeProof.Core.Pages
{
	public partial class SuperheroDetailsPage : ContentPage
	{
		public SuperheroDetailsPage()
		{
			InitializeComponent();
		}

		public void Handle_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new SuperheroComicsPage
			{
				BindingContext = new SuperheroComicsPageModel(
					(BindingContext as SuperheroDetailsPageModel).Superhero)
			});
		}
	}
}