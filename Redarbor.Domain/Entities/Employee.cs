using Redarbor.Domain.Shared.Enums;

namespace Redarbor.Domain.Entities;

public class Employee : Person
{
    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; } = null!;
    public Guid PortalId { get; set; }
    public virtual Portal Portal { get; set; } = null!;
    public Status Status { get; set; }
    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; } = null!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;

    public static Employee Create()
    {
        return new Employee();
    }
}
