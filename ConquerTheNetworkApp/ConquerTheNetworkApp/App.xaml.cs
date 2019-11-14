using Acr.UserDialogs;
using ConquerTheNetworkApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ConquerTheNetworkApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Connectivity.ConnectivityChanged += (sender, e) =>
            {
                string status = e.NetworkAccess == NetworkAccess.Internet ? "online" : "offline";
                Notify($"Your connection has changed. You are {status}.");
            };

            MainPage = new NavigationPage(new CitiesView());
        }

        protected void Notify(string message)
        {
            var config = new ToastConfig(message)
              .SetDuration(2000);

            UserDialogs.Instance.Toast(config);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
