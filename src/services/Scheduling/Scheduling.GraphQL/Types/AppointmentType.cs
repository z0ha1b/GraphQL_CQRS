using Scheduling.Application.Features.Appointment.Queries.DTOs;

namespace Scheduling.GraphQL.Types;

public class AppointmentType : ObjectType<GetAppointmentDto>
{
    protected override void Configure(IObjectTypeDescriptor<GetAppointmentDto> descriptor)
    {
        // descriptor.Field(x => x.).Type<IdType>();
        // descriptor.Field(x => x.Name).Type<StringType>();
        // Define other fields as needed.

        base.Configure(descriptor);
    }
}