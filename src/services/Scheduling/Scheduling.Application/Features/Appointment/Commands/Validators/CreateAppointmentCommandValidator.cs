using FluentValidation;
using Scheduling.Application.Features.Appointment.Commands.DTOs;

namespace Scheduling.Application.Features.Appointment.Commands.Validators;

public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
{
    public CreateAppointmentCommandValidator()
    {
        RuleFor(x => x.AppointmentDto)
            .NotNull()
            .WithMessage("Appointment cannot be empty.")
            .SetValidator(new CreateAppointmentDtoValidator());
    }
}