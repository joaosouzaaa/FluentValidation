namespace FluentValidation.API.Entities;

public sealed class Person
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required int Age { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required string Email { get; set; }
    public required string Cpf { get; set; }

    public Address Address { get; set; }
    public List<Phone> Phones { get; set; }
    public List<Skill> Skills { get; set; }
}
