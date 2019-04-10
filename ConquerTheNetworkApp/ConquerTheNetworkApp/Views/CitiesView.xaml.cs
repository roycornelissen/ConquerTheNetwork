using ConquerTheNetworkApp.Data;
using ConquerTheNetworkApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConquerTheNetworkApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CitiesView : ContentPage
	{
		private CitiesViewModel ViewModel
		{
			get => BindingContext as CitiesViewModel;
			set => BindingContext = value;
		}

		public CitiesView()
		{
			ViewModel = new CitiesViewModel();
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			ViewModel.GetCities();
		}

		private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var city = e.SelectedItem as City;

			await Navigation.PushAsync(new CityDetailView(city));
		}
	}
}