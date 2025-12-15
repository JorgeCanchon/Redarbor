namespace Redarbor.Domain.Entities;

public class Role : AuditableBaseEntity
{
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<Employee> Employees { get; set; } = [];
}