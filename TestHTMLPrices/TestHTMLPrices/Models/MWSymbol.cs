using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TestHTMLPrices
{
    public class MWSymbol : INotifyPropertyChanged
    {
        private readonly Random _random = new Random();

        public MWSymbol()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    Bid = (_random.NextDouble()*10).ToString("0.00000");
                    Ask = (_random.NextDouble()*10).ToString("0.00000");
                    await Task.Delay(200);
                }
            });

        }
        public int Id { get; internal set; }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        private string bid;

        public string Bid
        {
            get { return bid; }
            set
            {
                SetProperty(ref bid, FormatPrice(value));
            }
        }

        private string ask;

        public string Ask
        {
            get { return ask; }
            set
            {
                SetProperty(ref ask, FormatPrice(value));
            }
        }

        private string PricePrefix;
        private string PriceMain;
        private string PricePostfix;
        private string FormatPrice(string value)
        {
            int length = value.Length;
            if (length <= 2)
            {
                PricePrefix = "";
                PricePostfix = "";
                PriceMain = value;
            }
            else if (length == 3)
            {
                PricePrefix = "";
                PricePostfix = value.Substring(2, 1);
                PriceMain = value.Substring(0, 2);
            }
            else
            {
                var isMainHaveDot = value.Substring(length - 3, 2).Contains(".");
                if (isMainHaveDot)
                {
                    PricePrefix = value.Substring(0, length - 4);
                    PricePostfix = value.Substring(length - 1, 1);
                    PriceMain = value.Substring(length - 4, 3);
                }
                else
                {
                    PricePrefix = value.Substring(0, length - 3);
                    PricePostfix = value.Substring(length - 1, 1);
                    PriceMain = value.Substring(length - 3, 2);
                }
            }

           return $"<small><small><strong>{PricePrefix}</strong></small></small><strong>{PriceMain}</strong><sup><small><small><strong>{PricePostfix}</strong></small></small></sup>";
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