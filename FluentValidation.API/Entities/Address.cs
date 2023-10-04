﻿namespace FluentValidation.API.Entities;

public sealed class Address
{
    public required string ZipCode { get; set; }
    public required string Street { get; set; }
    public string? Complement { get; set; }
    public required string Number { get; set; }
    public required string District { get; set; }
    public required string City { get; set; }
}
