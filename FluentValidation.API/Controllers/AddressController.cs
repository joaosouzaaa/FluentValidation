using FluentValidation.API.Constants.RouteConstants;
using FluentValidation.API.Entities;
using FluentValidation.API.Interfaces.Services;
using FluentValidation.API.Settings.NotificationSettings;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

	public AddressController(IAddressService addressService)
	{
		_addressService = addressService;
    }

    /// <summary>
    /// Validate the address.
    /// </summary>
    /// <param name="address">The address request. Use default value:{"zipCode":"51260060","street":"Rua Irakitan","complement":"house 3","number":"123","district":"Jordão","city":"Recife", "state": "PE"}</param>
    /// <returns>If the address is valid.</returns>
    /// <response code="200">Validation was successful.</response>
    /// <response code="400">Validation happen with errors.</response>
    [HttpPost(AddressRouteConstants.ValidateAddress)]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
	[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
	public async Task<bool> ValidateAddressAsync([FromBody] Address address) =>
		await _addressService.ValidateAddressAsync(address);
}
