using Bogus;
using FluentValidation.API.Entities;
using FluentValidation.API.Enums;

namespace TestBuilders;
public sealed class PhoneBuilder
{
	private string _phoneNumber = "41995847523";
	
	public static PhoneBuilder NewObject() =>
		new PhoneBuilder();

	public Phone DomainBuild() =>
		new Phone()
		{
			PhoneNumber = _phoneNumber,
			PhoneType = new Faker().PickRandom<EPhoneType>()
		};

	public PhoneBuilder WithPhoneNumber(string phoneNumber)
	{
		_phoneNumber = phoneNumber;

		return this;
	}
}
