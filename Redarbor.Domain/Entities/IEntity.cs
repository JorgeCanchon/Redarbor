namespace Redarbor.Domain.Entities;

public interface IEntity<TId> where TId : IComparable, IComparable<TId>
{
    public TId Id { get; set; }
}
