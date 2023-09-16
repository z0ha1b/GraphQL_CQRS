using Microsoft.Extensions.Logging;
using Scheduling.Core.Entities;

namespace Scheduling.Infrastructure.Data;

public class SchedulingContextSeed
{
    public static async Task SeedAsync(SchedulingContext context, ILogger<SchedulingContextSeed> logger)
    {
        if (!context.Appointments.Any())
        {
            context.Appointments.AddRange(GetAppointments());
            await context.SaveChangesAsync();

            logger.LogInformation($"Scheduling Database seeded.");
        }
    }

    private static IEnumerable<Appointment> GetAppointments()
    {
        return new List<Appointment>
        {
            new()
            {
                CreatedDate = DateTime.Now,
                LastModifiedBy = null,
                LastModifiedDate = null,
                CreatedBy = Guid.NewGuid()
            }
        };
    }
}