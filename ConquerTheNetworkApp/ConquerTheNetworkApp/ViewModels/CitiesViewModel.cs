using System.Collections.Generic;
using System.Threading.Tasks;
using ConquerTheNetworkApp.Services;
using Xamarin.Forms;
using ConquerTheNetworkApp.Data;

namespace ConquerTheNetworkApp.ViewModels
{
    class CitiesViewModel : ViewModelBase
    {
        private Command refreshCommand;
        public Command RefreshCommand
        {
            get
            {
                return refreshCommand ??
                    (refreshCommand = new Command(async () => await ExecuteRefreshCommand(), () => !IsLoading));
            }
        }

        private async Task ExecuteRefreshCommand()
        {
            IsLoading = true;
            await GetCities();
            IsLoading = false;
        }

        public async Task GetCities()
        {
            var client = new ServiceClient();
            Cities = await client.GetCities();
        }

        private IEnumerable<City> _cities;
        public IEnumerable<City> Cities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                OnPropertyChanged();
            }
        }
    }
}
