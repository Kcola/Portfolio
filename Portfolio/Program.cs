using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Portfolio.Services;

namespace Portfolio
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(
                sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddStateProvider();
            builder.Services.AddJavaScriptInteropService();
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            var host = builder.Build();
            var js = host.Services.GetRequiredService<IJSRuntime>();
            var cultureName = await js.InvokeAsync<string>("portfolio.getCulture", new object[] { AppCulture.Supported });
            var culture = CultureInfo.GetCultureInfo(cultureName);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;

            await host.RunAsync();
        }
    }
}
