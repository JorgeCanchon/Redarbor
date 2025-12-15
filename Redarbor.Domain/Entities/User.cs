namespace Redarbor.Domain.Entities;

public class User : AuditableBaseEntity
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime? LastLogin { get; set; }
    public Guid EmployeeId { get; set; }
    public virtual Employee Employee { get; set; } = null!;

    public static new User Create()
    {
        return new User();
    }
}
