using FluentValidation.API.Enums;

namespace FluentValidation.API.Entities;

public sealed class Phone
{
    public required string PhoneNumber { get; set; }
    public required EPhoneType PhoneType { get; set; }
}
