using CadastroClientQ.Domain.Adapters;
using IBGEServicoDados.ApiAdapter;
using IBGEServicoDados.ApiAdapter.Configuration;
using Refit;
using ServicoDadosIBGE.ApiAdapter.Clients;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IBGEApiDependencyInjection
    {
        public static IServiceCollection AddIBGEApi(
           this IServiceCollection services,
           IBGEApiConfiguration ibgeApiConfiguration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (ibgeApiConfiguration == null)
                throw new ArgumentNullException(nameof(ibgeApiConfiguration));

            services.AddSingleton(ibgeApiConfiguration);

            services.AddRefitClient<IClientIBGEApi>()
                .ConfigureHttpClient(
                    c => c.BaseAddress = new Uri(ibgeApiConfiguration.ApiUrlBase)
                );

            services.AddScoped<IIBGEApi, IBGEApi>();

            return services;
        }
    }
}
