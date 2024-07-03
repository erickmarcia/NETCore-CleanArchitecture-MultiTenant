using Microsoft.Extensions.DependencyInjection;

namespace MultiTenantService.Common
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddCommon(this IServiceCollection
            services)
        {
            return services;
        }
    }
}
