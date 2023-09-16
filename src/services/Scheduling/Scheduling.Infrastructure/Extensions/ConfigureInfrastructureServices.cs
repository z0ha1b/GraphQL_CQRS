using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scheduling.Core.Repositories;
using Scheduling.Infrastructure.Data;
using Scheduling.Infrastructure.Repositories;

namespace Scheduling.Infrastructure.Extensions;

public static class ConfigureInfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<SchedulingContext>(options => options.UseSqlServer(configuration.GetConnectionString("SchedulingConnectionString")));
        serviceCollection.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        serviceCollection.AddScoped<IAppointmentRepository, AppointmentRepository>();

        return serviceCollection;
    }
}