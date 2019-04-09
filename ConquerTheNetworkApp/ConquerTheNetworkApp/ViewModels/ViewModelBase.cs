using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Acr.UserDialogs;

namespace ConquerTheNetworkApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        protected void Notify(string message)
        {
            var config = new ToastConfig(message)
                .SetDuration(2000);

            UserDialogs.Instance.Toast(config);
        }
    }
}
