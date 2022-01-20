using System.Collections.ObjectModel;

namespace TestHTMLPrices
{
    public class Buffers
    {
        public ObservableCollection<MWSymbol> SymbolsBuffer { get; set; }
        public Buffers()
        {
            SymbolsBuffer = new ObservableCollection<MWSymbol>();

            for (int i = 0; i < 100; i++)
            {
                MWSymbol symbol = new MWSymbol
                {
                    Id = i,
                    Name= i.ToString()
                };
                SymbolsBuffer.Add(symbol);
            }
        }
    }
}