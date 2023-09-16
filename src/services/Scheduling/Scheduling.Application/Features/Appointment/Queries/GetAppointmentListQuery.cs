using MediatR;
using Scheduling.Application.Features.Appointment.Queries.DTOs;
using Scheduling.Application.Features.Common.DTOs;

namespace Scheduling.Application.Features.Appointment.Queries;

public class GetAppointmentListQuery : BaseQueryPayload<List<GetAppointmentDto>>
{
    public Guid UserId { get; set; }

    public GetAppointmentListQuery(Guid userId)
    {
        UserId = userId;
    }
    
    public GetAppointmentListQuery()
    {
    }
}