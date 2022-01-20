using System;
using Xamarin.Forms;

namespace TestHTMLPrices
{
    internal class VertexAppManager
    {
        private static readonly Lazy<VertexAppManager> lazy = new Lazy<VertexAppManager>(() => new VertexAppManager());
        public static VertexAppManager Instance { get { return lazy.Value; } }
        private VertexAppManager()
        {
            DataBuffer = new Buffers();
        }
        public Buffers DataBuffer { get; set; }
        public INavigation Navigation { get; internal set; }
    }
}