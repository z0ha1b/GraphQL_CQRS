using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Application.Features.Appointment.Queries;
using Scheduling.Application.Features.Appointment.Queries.DTOs;

namespace Scheduling.API.Controllers;

public class AppointmentController : BaseController
{
    private readonly IMediator _mediator;

    public AppointmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId:guid}", Name = "GetAllAppointmentsOfUser")]
    [ProducesResponseType(typeof(IEnumerable<GetAppointmentDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<GetAppointmentDto>>> GetAllAppointmentsOfUser(Guid userId)
    {
        var query = new GetAppointmentListQuery();
        var appointments = await _mediator.Send(query);

        return Ok(appointments);
    }

    [HttpGet(Name = "GetAllAppointments")]
    [ProducesResponseType(typeof(IEnumerable<GetAppointmentDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<GetAppointmentDto>>> GetAllAppointments()
    {
        var query = new GetAppointmentListQuery();
        var appointments = await _mediator.Send(query);

        return Ok(appointments);
    }
}