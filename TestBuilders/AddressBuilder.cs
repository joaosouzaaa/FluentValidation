using FluentValidation.API.Entities;

namespace TestBuilders;
public sealed class AddressBuilder
{
	private string _city = "random city";
	private string? _complement = "randomComplement";
	private string _district = "ssdiadkoasd";
	private string _number = "123";
	private string _street = "random";
	private string _zipCode = "12345678";

	public static AddressBuilder NewObject() => 
		new AddressBuilder();

	public Address DomainBuild() =>
		new Address()
		{
			City = _city,
			Complement = _complement,
			District = _district,
			Number = _number,
			Street = _street,
			ZipCode = _zipCode
		};

	public AddressBuilder WithCity(string city)
	{
		_city = city;

		return this;
	}

	public AddressBuilder WithZipCode(string zipCode)
	{
		_zipCode = zipCode;

		return this;
	}

	public AddressBuilder WithStreet(string street)
	{
		_street = street;

		return this;
	}

	public AddressBuilder WithComplement(string complement)
	{
		_complement = complement;

		return this;
	}

	public AddressBuilder WithNumber(string number)
	{
		_number = number;

		return this;
	}

	public AddressBuilder WithDistrict(string district)
	{
		_district = district;

		return this;
	}
}
