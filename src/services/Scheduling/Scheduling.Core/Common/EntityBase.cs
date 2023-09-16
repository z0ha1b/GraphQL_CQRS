namespace Scheduling.Core.Common;

public abstract class EntityBase
{
    public long Id { get; set; }
    
    public Guid CreatedBy { get; set; }
    public Guid? LastModifiedBy { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}