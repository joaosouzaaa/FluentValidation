using FluentValidation.API.Entities;

namespace TestBuilders;
public sealed class PersonBuilder
{
	private string _firstName = "first";
	private string _lastName = "last";
	private int _age = 123;
	private DateTime _birthDate = new DateTime(2001, 01, 01);
	private string _email = "random@email.com";
	private string _cpf = "19649020020";
	private Address _address = AddressBuilder.NewObject().DomainBuild();
	private List<Phone> _phoneList = new List<Phone>()
    {
        PhoneBuilder.NewObject().DomainBuild(),
        PhoneBuilder.NewObject().DomainBuild(),
        PhoneBuilder.NewObject().DomainBuild()
    };
	private List<Skill> _skillList = new List<Skill>()
    {
        SkillBuilder.NewObject().DomainBuild()
    };

    public static PersonBuilder NewObject() =>
		new PersonBuilder();

	public Person DomainBuild() =>
		new Person()
		{
			Age = _age,
			Address = _address,
			BirthDate = _birthDate,
			Cpf = _cpf,
			Email = _email,
			FirstName = _firstName,
			LastName = _lastName,
			Phones = _phoneList,
			Skills = _skillList
		};

	public PersonBuilder WithAddress(Address address)
	{
		_address = address;

		return this;
	}

	public PersonBuilder WithPhoneList(List<Phone> phoneList)
	{
		_phoneList = phoneList;

		return this;
	}

	public PersonBuilder WithSkillList(List<Skill> skillList)
	{
		_skillList = skillList;

        return this;
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
