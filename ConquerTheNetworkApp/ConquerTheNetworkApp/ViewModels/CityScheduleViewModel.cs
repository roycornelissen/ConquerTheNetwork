using System.Linq;
using System.Threading.Tasks;
using ConquerTheNetworkApp.Data;
using ConquerTheNetworkApp.Services;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using MvvmHelpers;
using Xamarin.Essentials;
using System;

namespace ConquerTheNetworkApp.ViewModels
{
    public class CityScheduleViewModel : ViewModelBase
    {
        private string _cityId;

        public CityScheduleViewModel(string cityId, string cityName)
        {
            _cityId = cityId;
            _cityName = cityName;
            _groupedSlots = new ObservableRangeCollection<Grouping<string, Slot>>();
        }

        private ObservableRangeCollection<Grouping<string, Slot>> _groupedSlots;
        public ObservableCollection<Grouping<string, Slot>> GroupedSlots
        {
            get
            {
                return _groupedSlots;
            }
        }

        private string _cityName;
        public string CityName
        {
            get { return _cityName; }
        }

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
            await GetSchedule();
            IsLoading = false;
        }

        public async Task GetSchedule()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                Notify("You seem to be offline... Try again later.");
                return;
            }

            try
            {
                var client = new ServiceClient();
                var schedule = await client.GetScheduleForCity(_cityId);

                if (schedule != null)
                {
                    await Task.Run(() => from slot in schedule.Slots
                                         orderby slot.StartTime
                                         group slot by slot.DayFormatted
                                         into slotGroup
                                         select new Grouping<string, Slot>(slotGroup.Key, slotGroup)).ContinueWith(r =>
                                         {
                                             _groupedSlots.ReplaceRange(r.Result);
                                         });
                }
            }
            catch (Exception e)
            {
                Notify($"Something went wrong: {e.Message}");
            }
        }
    }
}
