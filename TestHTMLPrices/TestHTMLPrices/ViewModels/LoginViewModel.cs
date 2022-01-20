using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace TestHTMLPrices
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public ICommand LoginButtonCommand { get; }

        public LoginViewModel()
        {
            LoginButtonCommand = new Command(() => LoginButtonClicked());
        }


        private async void LoginButtonClicked()
        {
            await VertexAppManager.Instance.Navigation.PushAsync(new MainPage()).ConfigureAwait(false);
        }
        #region INotifyPropertyChanged

        protected bool SetProperty<T>(ref T backingStore, T value,
        [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            // try
            {
                var changed = PropertyChanged;
                if (changed == null)
                    return;
                changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            //catch (Exception ex)
            {
                //  throw;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        #endregion INotifyPropertyChanged
    }
}
