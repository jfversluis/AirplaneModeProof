using AirplaneModeProof.Core.Pages;
using Akavache;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AirplaneModeProof.Core
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			BlobCache.ApplicationName = "AirplaneModeProofApp";

			MainPage = new NavigationPage(new MainPage())
			{
				BarBackgroundColor = Color.FromHex("#ED1120"),
				BarTextColor = Color.White
			};
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			BlobCache.Shutdown().Wait();
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}