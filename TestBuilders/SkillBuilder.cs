using Bogus;
using FluentValidation.API.Entities;
using FluentValidation.API.Enums;

namespace TestBuilders;
public sealed class SkillBuilder
{
	private string _name = "name";
	private int _experienceYears = 10;

	public static SkillBuilder NewObject() =>
		new SkillBuilder();

	public Skill DomainBuild() =>
		new Skill()
		{
			Category = new Faker().PickRandom<ESkillCategory>(),
			ExperienceYears = _experienceYears,
			Name = _name
		};

	public SkillBuilder WithExperienceYears(int experienceYears)
	{
		_experienceYears = experienceYears;

		return this;
	}

	public SkillBuilder WithName(string name)
	{
		_name = name;

		return this;
	}
}
