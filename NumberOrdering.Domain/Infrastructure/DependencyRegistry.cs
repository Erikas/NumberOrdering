using Microsoft.Extensions.DependencyInjection;
using NumberOrdering.Persistence.Contracts;
using NumberOrdering.Persistence.Providers;
using NumberOrdering.Domain.Services;
using NumberOrdering.Infrastructure.Sorters.Contracts;

namespace NumberOrdering.Domain.Infrastructure
{
    public static class DependencyRegistry
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IDataManagerProvider, FileSystemDataManagerProvider>();
            services.AddScoped<INumberOrderingService, NumberOrderingService>();
            services.AddScoped<IDataManagerProviderService, DataManagerProviderService>();
            services.AddScoped<ICustomArraySorter<int>, IntegerArrayIntersectionSorter>();
        }
    }
}
