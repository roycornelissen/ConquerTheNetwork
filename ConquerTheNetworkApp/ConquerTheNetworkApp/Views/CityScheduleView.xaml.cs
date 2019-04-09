using ConquerTheNetworkApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConquerTheNetworkApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CityScheduleView : ContentPage
	{
		private CityScheduleViewModel ViewModel
		{
			get => BindingContext as CityScheduleViewModel;
			set => BindingContext = value;
		}

		public CityScheduleView(CityScheduleViewModel viewModel)
		{
			ViewModel = viewModel;
			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			await ViewModel.GetSchedule();
		}

		public void Schedule_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
		}
	}
}