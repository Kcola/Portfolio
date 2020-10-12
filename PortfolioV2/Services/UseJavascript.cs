using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace PortfolioV2.Services
{
    public class UseJavascript
    {
        private readonly IJSRuntime _js;

        public UseJavascript(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<BrowserDimension> GetDimensions()
        {
            return await _js.InvokeAsync<BrowserDimension>("getDimensions");
        }
    }
    public class BrowserDimension
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}