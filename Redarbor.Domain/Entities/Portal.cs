namespace Redarbor.Domain.Entities;

public class Portal : AuditableBaseEntity
{
    public string Name { get; set; } = null!;
    public virtual ICollection<Employee> Employees { get; set; } = [];

    public static Portal Create(string name)
     => new()
     {
         Name = name,
         Id = Guid.NewGuid(),
         CreatedOn = DateTime.UtcNow
     };
}
