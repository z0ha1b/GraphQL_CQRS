using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Scheduling.Application.Features.Appointment.Queries.DTOs;
using Scheduling.GraphQL.Queries;

namespace Scheduling.GraphQL.Extensions
{
    public static class ConfigureGraphQL
    {
        public static IServiceCollection AddGraphQLServices(this IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType<AppointmentQuery>()
                .AddType<GetAppointmentDto>()
                .AddFiltering()
                .AddSorting();

            return services;
        }

        public static void ConfigureEndPoint(this WebApplication app)
        {
            app.MapGraphQL();
        }
    }
}