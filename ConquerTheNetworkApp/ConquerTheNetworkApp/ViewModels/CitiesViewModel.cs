using Akavache;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConquerTheNetworkApp.Services;
using Xamarin.Forms;
using ConquerTheNetworkApp.Data;
using MvvmHelpers;
using System.Collections.ObjectModel;
using Plugin.Connectivity;

namespace ConquerTheNetworkApp.ViewModels
{
	class CitiesViewModel : ViewModelBase
	{
		public CitiesViewModel()
		{
			_cities = new ObservableRangeCollection<City>();
		}

		private Command refreshCommand;
		public Command RefreshCommand
		{
			get
			{
				return refreshCommand ??
					(refreshCommand = new Command(() => ExecuteRefreshCommand(), () => !IsLoading));
			}
		}

		private void ExecuteRefreshCommand()
		{
			IsLoading = true;
			GetCities(force: true);
			IsLoading = false;
		}

		public void GetCities(bool force = false)
		{
			if (force && !CrossConnectivity.Current.IsConnected)
			{
				Notify("You seem to be offline... Try again later.");
				return;
			}

			var cache = BlobCache.LocalMachine;
			cache.GetAndFetchLatest("cities", GetRemoteCitiesAsync,
				offset =>
				{
					TimeSpan elapsed = DateTimeOffset.Now - offset;
					var invalidate = (force || elapsed > new TimeSpan(hours: 0, minutes: 30, seconds: 0));
					return invalidate;
				})
				.Subscribe((cities) =>
				{
					_cities.ReplaceRange(cities);
				});
		}

		private async Task<List<City>> GetRemoteCitiesAsync()
		{
			var client = new ServiceClient();
			return await client.GetCities();
		}

		private ObservableRangeCollection<City> _cities;
		public ObservableCollection<City> Cities
		{
			get { return _cities; }
		}
	}
}
