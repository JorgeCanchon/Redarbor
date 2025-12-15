namespace Redarbor.Domain.Entities;

public class User : AuditableBaseEntity
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime? LastLogin { get; set; }
    public virtual Employee Employee { get; set; } = null!;

    public static User Create(string username, string password)
    => new()
    {
        Id = Guid.NewGuid(),
        CreatedOn = DateTime.UtcNow,
        LastLogin = DateTime.UtcNow,
        Password = password,
        Username = username,
    };
}
