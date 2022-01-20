using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TestHTMLPrices.Views;
using Xamarin.Forms;

namespace TestHTMLPrices
{
    internal class QuotesViewModel
    {
        public QuotesViewModel()
        {
      
        }
        public ObservableCollection<MWSymbol> Symbols
        {
            get
            {
                return VertexAppManager.Instance.DataBuffer.SymbolsBuffer;
            }
        }
    }
}
