using FluentValidation.API.Enums;

namespace FluentValidation.API.Entities;

public sealed class Skill
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ESkillCategory Category { get; set; }

    public List<Person> Persons { get; set; }
}
