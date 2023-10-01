using FluentValidation.API.Enums;

namespace FluentValidation.API.Entities;

public sealed class Skill
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required ESkillCategory Category { get; set; }

    public List<Person> Persons { get; set; }
}
