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

    /*
	{
  "zipCode": "82624196",
  "street": "aaaaaaaaaa",
  "complement": "aaaaa",
  "number": "aaaaaa",
  "district": "aaaaaaa",
  "city": "aaaaaaa"
}
	 */
    [HttpPost(AddressRouteConstants.ValidateAddress)]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
	[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
	public async Task<bool> ValidateAddressAsync([FromBody] Address address) =>
		await _addressService.ValidateAddressAsync(address);
}
