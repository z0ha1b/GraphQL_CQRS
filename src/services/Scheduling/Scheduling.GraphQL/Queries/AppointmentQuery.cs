using MediatR;
using Scheduling.Application.Features.Appointment.Queries;
using Scheduling.Application.Features.Appointment.Queries.DTOs;

namespace Scheduling.GraphQL.Queries;

public class AppointmentQuery
{
    public async Task<IEnumerable<GetAppointmentDto>> GetAppointments([Service] IMediator mediator, GetAppointmentListQuery model)
    {
        return await mediator.Send(model);
    }
}