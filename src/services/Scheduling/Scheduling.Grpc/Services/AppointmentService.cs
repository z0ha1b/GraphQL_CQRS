using Grpc.Core;
using MediatR;
using Scheduling.Application.Features.Appointment.Commands;
using Scheduling.Application.Features.Appointment.Commands.DTOs;

namespace Scheduling.Grpc.Services;

public class AppointmentService : Appointment.AppointmentBase
{
    private readonly ILogger<AppointmentService> _logger;
    private readonly IMediator _mediator;

    public AppointmentService(ILogger<AppointmentService> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public override async Task<CreateAppointmentResponse> CreateAppointment(CreateAppointmentRequest request, ServerCallContext context)
    {
        //use validator here
        if (string.IsNullOrEmpty(request.Subject) && string.IsNullOrEmpty(request.CreatedBy))
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "You must supply valid objects."));
        }

        // use automapper here
        var createAppointmentCommand = new CreateAppointmentCommand
        {
            AppointmentDto = new CreateAppointmentDto
            {
                Subject = request.Subject,
                CreatedBy = Guid.Parse(request.CreatedBy)
            }
        };

        var id = await _mediator.Send(createAppointmentCommand);

        return new CreateAppointmentResponse
        {
            Id = id
        };
    }
}