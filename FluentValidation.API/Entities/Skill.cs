using FluentValidation.API.Enums;

namespace FluentValidation.API.Entities;

public sealed class Skill
{
    public required string Name { get; set; }
    public required ESkillCategory Category { get; set; }
    public required int ExperienceYears { get; set; }
}
