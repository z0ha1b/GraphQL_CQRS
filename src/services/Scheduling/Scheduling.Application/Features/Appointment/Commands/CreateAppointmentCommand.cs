using MediatR;
using Scheduling.Application.Features.Appointment.Commands.DTOs;

namespace Scheduling.Application.Features.Appointment.Commands;

public class CreateAppointmentCommand : IRequest<long>
{
    public CreateAppointmentDto? AppointmentDto { get; set; }
}