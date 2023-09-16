using AutoMapper;
using Scheduling.Application.Features.Appointment.Commands.DTOs;
using Scheduling.Application.Features.Appointment.Queries.DTOs;
using Scheduling.Core.Entities;

namespace Scheduling.Application.Mappers;

public class AppointmentMappingProfile : Profile
{
    public AppointmentMappingProfile()
    {
        CreateMap<Appointment, CreateAppointmentDto>().ReverseMap();
        CreateMap<Appointment, GetAppointmentDto>().ReverseMap();
    }
}