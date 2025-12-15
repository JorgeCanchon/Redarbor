namespace Redarbor.Domain.Entities;

public class Company : AuditableBaseEntity
{
    public string Name { get; set; } = null!;
    public virtual ICollection<Employee> Employees { get; set; } = [];
}
