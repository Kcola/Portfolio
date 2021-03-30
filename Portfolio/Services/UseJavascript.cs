using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Portfolio.Services
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

        public async Task Redirect(string url)
        {
            await _js.InvokeVoidAsync("Redirect", url);
        }
    }
    public class BrowserDimension
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}