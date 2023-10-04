using FluentValidation.API.Entities;

namespace TestBuilders;
public sealed class PersonBuilder
{
	private string _firstName = "first";
	private string _lastName = "last";
	private int _age = 123;
	private DateTime _birthDate = new DateTime(2022, 01, 01);
	private string _email = "random@email.com";
	private string _cpf = "19649020020";

    public static PersonBuilder NewObject() =>
		new PersonBuilder();

	public Person DomainBuild()
	{
		var address = AddressBuilder.NewObject().DomainBuild();
		
		var phoneList = new List<Phone>()
		{
			PhoneBuilder.NewObject().DomainBuild(),
			PhoneBuilder.NewObject().DomainBuild(),
			PhoneBuilder.NewObject().DomainBuild()
		};
		
		var skillList = new List<Skill>()
		{
			SkillBuilder.NewObject().DomainBuild()
		};

		return new Person()
		{
			Age = _age,
			Address = address,
			BirthDate = _birthDate,
			Cpf = _cpf,
			Email = _email,
			FirstName = _firstName,
			LastName = _lastName,
			Phones = phoneList,
			Skills = skillList
		};
	}

	public PersonBuilder WithFirstName(string firstName)
	{
		_firstName = firstName;

		return this;
	}

    public PersonBuilder WithLastName(string lastName)
    {
        _lastName = lastName;

        return this;
    }

	public PersonBuilder WithAge(int age)
	{
		_age = age;

		return this;
	}

	public PersonBuilder WithBirthDate(DateTime birthDate)
	{
		_birthDate = birthDate;

		return this;
	}

	public PersonBuilder WithEmail(string email)
	{
		_email = email;

		return this;
	}

	public PersonBuilder WithCpf(string cpf)
	{
		_cpf = cpf;

		return this;
	}
}
