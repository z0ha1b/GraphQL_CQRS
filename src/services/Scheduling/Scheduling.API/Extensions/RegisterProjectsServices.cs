using Scheduling.Application.Extensions;
using Scheduling.Infrastructure.Extensions;

namespace Scheduling.API.Extensions;

public static class RegisterProjectsServices
{
    public static IServiceCollection AddProjectsServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddApplicationServices();
        serviceCollection.AddInfrastructureServices(configuration);

        return serviceCollection;
    }
}