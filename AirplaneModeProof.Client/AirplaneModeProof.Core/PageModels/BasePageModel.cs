using System.ComponentModel;

namespace AirplaneModeProof.Core.PageModels
{
	public class BasePageModel : INotifyPropertyChanged
	{
		public bool IsLoading { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;
	}
}