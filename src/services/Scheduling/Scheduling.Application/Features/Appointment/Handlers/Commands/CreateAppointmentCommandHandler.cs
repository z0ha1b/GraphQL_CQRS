using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Scheduling.Application.Features.Appointment.Commands;
using Scheduling.Core.Repositories;

namespace Scheduling.Application.Features.Appointment.Handlers.Commands;

public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, long>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateAppointmentCommandHandler> _logger;

    public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper, ILogger<CreateAppointmentCommandHandler> logger)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<long> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        if (request.AppointmentDto is null)
        {
            throw new ValidationException("Null");
        }

        var appointment = _mapper.Map<Core.Entities.Appointment>(request.AppointmentDto);
        var createdAppointment = await _appointmentRepository.AddAsync(appointment);
        return createdAppointment.Id;
    }
}