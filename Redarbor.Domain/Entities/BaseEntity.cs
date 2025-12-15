namespace Redarbor.Domain.Entities;

public abstract class BaseEntity : IEntity<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
