using FluentValidation.API.Enums;

namespace FluentValidation.API.Entities;

public sealed class Phone
{
    public int Id { get; set; } 
    public string PhoneNumber { get; set; }
    public EPhoneType PhoneType { get; set; }
    
    public int PersonId { get; set; }
}
