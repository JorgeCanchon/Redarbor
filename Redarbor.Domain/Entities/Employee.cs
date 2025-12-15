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
    public Guid? UserId { get; set; }
    public virtual User User { get; set; } = null!;

    public static Employee Create(string name, string email, string telephone, string fax, Guid portalId, Guid companyId, Guid roleId, Status status)
    => new()
    {
        Name = name,
        Email = email,
        Status = status,
        CreatedOn = DateTime.UtcNow,
        Id = Guid.NewGuid(),
        PortalId = portalId,
        CompanyId = companyId,
        RoleId = roleId,
        Fax = fax,
        Telephone = telephone
    };

    public void AddUser(string name, string password)
    {
        User = User.Create(name, password);
    }

    public void LogicalDelete()
    {
        Status = Status.Inactive;
        DeletedOn = DateTime.UtcNow;
    }

    public void Reactivate()
    {
        Status = Status.Active;
        DeletedOn = null;
    }

    public void Update(string name, string email, string telephone, string fax, Guid portalId, Guid companyId, Guid roleId, Status status)
    {
        Name = name;
        Email = email;
        Telephone = telephone;
        Fax = fax;
        RoleId = roleId;
        Status = status;
        UpdatedOn = DateTime.UtcNow;
        PortalId = portalId;
        CompanyId = companyId;
        RoleId = roleId;
    }
}
