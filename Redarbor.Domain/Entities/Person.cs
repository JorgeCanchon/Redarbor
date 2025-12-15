namespace Redarbor.Domain.Entities;

public abstract class Person : AuditableBaseEntity
{
    public string? Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Telephone { get; set; } = string.Empty;
    public string Fax { get; set; } = null!;
}
