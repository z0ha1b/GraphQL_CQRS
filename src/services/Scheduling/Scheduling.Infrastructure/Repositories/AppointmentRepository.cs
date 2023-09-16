using Microsoft.EntityFrameworkCore;
using Scheduling.Core.Entities;
using Scheduling.Core.Repositories;
using Scheduling.Infrastructure.Data;

namespace Scheduling.Infrastructure.Repositories;

public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(SchedulingContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsByUserId(Guid userId)
    {
        var appointmentList = await DbContext.Appointments
            .Where(a => a.CreatedBy == userId)
            .ToListAsync();

        return appointmentList;
    }
}