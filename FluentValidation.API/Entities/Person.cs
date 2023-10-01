namespace FluentValidation.API.Entities;

public sealed class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }

    public int AddressId { get; set; }
    public Address Address { get; set; }
    public List<Phone> Phones { get; set; }
    public List<Skill> Skills { get; set; }
}
