using Microsoft.Extensions.DependencyInjection;

namespace PortfolioV2.Services
{
    public static class ServicesConfiguration
    {
        public static void AddStateProvider(this IServiceCollection services)
        {
            services.AddSingleton<IStateProvider, StateProvider>();
        } 
    }
}