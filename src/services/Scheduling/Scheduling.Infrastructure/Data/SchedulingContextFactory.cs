using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Scheduling.Infrastructure.Data;

public class SchedulingContextFactory : IDesignTimeDbContextFactory<SchedulingContext>
{
    public SchedulingContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SchedulingContext>();
        optionsBuilder.UseSqlServer("Data Source=SchedulingDb");

        return new SchedulingContext(optionsBuilder.Options);
    }
}