using Microsoft.EntityFrameworkCore;

namespace CqrsTemplate;

public enum Gender
{
    Male,
    Female,
    Other,
    Unknown
}

public class User
{
    public Guid Id { get; set; }

    public required string GivenName { get; set; }
    public required string Surname { get; set; }
    public Gender? Gender { get; set; }
    public DateOnly? BirthDate { get; set; }
    public string? BirthLocation { get; set; }
    public DateOnly? DeathDate { get; set; }
    public string? DeathLocation { get; set; }


    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }

    public void OnBeforeSave(DbContext context)
    {
        if (Id == Guid.Empty)
        {
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;
        }
        else
        {
            // update with user context
            LastModifiedBy = "Unknown";
            LastModifiedDate = DateTime.UtcNow;
        }
    }
}

