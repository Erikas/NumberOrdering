using NumberOrdering.WebAPI.ApplicationService;

namespace NumberOrdering.WebAPI.Infrastructure
{
    public static class DependencyRegistry
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<INumberOrderingApplicationService, NumberOrderingApplicationService>();
        }
    }
}
