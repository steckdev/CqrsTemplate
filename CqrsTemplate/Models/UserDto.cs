using Microsoft.EntityFrameworkCore;

namespace cqrs_template;

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

}

