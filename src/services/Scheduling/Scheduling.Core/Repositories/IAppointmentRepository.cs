using Scheduling.Core.Entities;

namespace Scheduling.Core.Repositories;

public interface IAppointmentRepository : IAsyncRepository<Appointment>
{
    Task<IEnumerable<Appointment>> GetAppointmentsByUserId(Guid userId);
}