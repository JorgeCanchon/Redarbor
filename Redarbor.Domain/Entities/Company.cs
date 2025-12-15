namespace Redarbor.Domain.Entities;

public class Company : AuditableBaseEntity
{
    public string Name { get; set; } = null!;
    public virtual ICollection<Employee> Employees { get; set; } = [];
    public static Company Create(string name)
    => new()
    {
        Id = Guid.NewGuid(),
        Name = name
    };
}
