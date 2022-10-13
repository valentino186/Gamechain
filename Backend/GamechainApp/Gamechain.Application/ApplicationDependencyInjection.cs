using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Gamechain.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationDependencyInjection).Assembly);

            return services;
        }
    }
}
