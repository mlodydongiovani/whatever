using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Promise.Application.Books;
using Promise.Application.Orders;
using Promise.Clients.Authentication;
using Promise.Clients.Authentication.Common;
using Promise.Clients.Books;
using Promise.Clients.Orders;

namespace Promise.Infrastructure
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection AddClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAuthenticationTokenProvider, AuthenticationTokenProvider>();

            var apiUrl = configuration["apiUrl"];

            if(apiUrl == null)
            {
                throw new ApplicationException($"{nameof(apiUrl)} was null.");
            }

            services.AddHttpClient<IBooksClient, BooksClient>((client) =>
            {
                client.BaseAddress = new Uri(apiUrl!);
            })
            .AddHttpMessageHandler<BearerTokenHandler>();

            services.AddHttpClient<IOrdersClient, OrdersClient>((client) =>
            {
                client.BaseAddress = new Uri(apiUrl!);
            })
            .AddHttpMessageHandler<BearerTokenHandler>();

            return services;
        }
    }
}
