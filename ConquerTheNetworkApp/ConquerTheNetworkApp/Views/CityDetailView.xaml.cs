using ConquerTheNetworkApp.Data;
using ConquerTheNetworkApp.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConquerTheNetworkApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CityDetailView : ContentPage
	{
		private CityDetailViewModel ViewModel
		{
			get => BindingContext as CityDetailViewModel;
			set => BindingContext = value;
		}

		public CityDetailView(City city)
		{
			ViewModel = new CityDetailViewModel(this, city);
			InitializeComponent();
		}

		void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
		{
			var newStep = Math.Round(e.NewValue / 1.0);
			RatingSlider.Value = newStep * 1.0;
		}
	}
}