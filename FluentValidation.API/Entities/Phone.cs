using FluentValidation.API.Enums;

namespace FluentValidation.API.Entities;

public sealed class Phone
{
    public int Id { get; set; } 
    public required string PhoneNumber { get; set; }
    public required EPhoneType PhoneType { get; set; }
    
    public int PersonId { get; set; }
}
