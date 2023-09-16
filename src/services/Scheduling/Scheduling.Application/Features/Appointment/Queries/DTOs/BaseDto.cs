namespace Scheduling.Application.Features.Appointment.Queries.DTOs;

public class BaseDto
{
    public long Id { get; set; }

    public Guid CreatedBy { get; set; }
    public Guid? LastModifiedBy { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}