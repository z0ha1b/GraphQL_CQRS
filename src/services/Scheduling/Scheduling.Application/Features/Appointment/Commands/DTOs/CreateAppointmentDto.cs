using Scheduling.Application.Features.Common.DTOs;

namespace Scheduling.Application.Features.Appointment.Commands.DTOs;

public class CreateAppointmentDto : BaseCommandDto
{
    public string? Subject { get; set; }
}