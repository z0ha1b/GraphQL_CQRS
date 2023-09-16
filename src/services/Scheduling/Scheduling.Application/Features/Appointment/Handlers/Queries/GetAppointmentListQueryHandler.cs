using AutoMapper;
using MediatR;
using Scheduling.Application.Features.Appointment.Queries;
using Scheduling.Application.Features.Appointment.Queries.DTOs;
using Scheduling.Core.Repositories;

namespace Scheduling.Application.Features.Appointment.Handlers.Queries;

public class GetAppointmentListQueryHandler : IRequestHandler<GetAppointmentListQuery, List<GetAppointmentDto>>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;

    public GetAppointmentListQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAppointmentDto>> Handle(GetAppointmentListQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Core.Entities.Appointment> appointments;

        if (request.UserId != Guid.Empty)
        {
            appointments = await _appointmentRepository.GetAppointmentsByUserId(request.UserId);
            return _mapper.Map<List<GetAppointmentDto>>(appointments);
        }

        appointments = await _appointmentRepository.GetAllAsync();

        return _mapper.Map<List<GetAppointmentDto>>(appointments);
    }
}