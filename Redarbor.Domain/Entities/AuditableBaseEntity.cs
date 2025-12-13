namespace Redarbor.Domain.Entities;

public class AuditableBaseEntity : BaseEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
}
