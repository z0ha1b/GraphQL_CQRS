using System.Runtime.Intrinsics.X86;
using FluentValidation;
using Scheduling.Application.Features.Appointment.Commands.DTOs;

namespace Scheduling.Application.Features.Appointment.Commands.Validators;

public class CreateAppointmentDtoValidator : AbstractValidator<CreateAppointmentDto>
{
    public CreateAppointmentDtoValidator()
    {
        RuleFor(x => x.Subject)
            .NotNull()
            .WithMessage("Subject cannot be null.");
    }
}