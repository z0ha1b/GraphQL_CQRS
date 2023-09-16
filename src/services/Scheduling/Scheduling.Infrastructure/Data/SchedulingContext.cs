using Microsoft.EntityFrameworkCore;
using Scheduling.Core.Common;
using Scheduling.Core.Entities;

namespace Scheduling.Infrastructure.Data;

public class SchedulingContext : DbContext
{
    public SchedulingContext(DbContextOptions<SchedulingContext> options) : base(options)
    {
    }

    public DbSet<Appointment> Appointments { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}