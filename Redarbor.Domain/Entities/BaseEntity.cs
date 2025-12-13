namespace Redarbor.Domain.Entities;

public class BaseEntity : IEntity<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
