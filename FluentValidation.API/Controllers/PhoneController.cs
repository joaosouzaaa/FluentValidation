using FluentValidation.API.Constants.RouteConstants;
using FluentValidation.API.Entities;
using FluentValidation.API.Interfaces.Services;
using FluentValidation.API.Settings.NotificationSettings;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class PhoneController : ControllerBase
{
    private readonly IPhoneService _phoneService;

	public PhoneController(IPhoneService phoneService)
	{
		_phoneService = phoneService;
	}

    /// <summary>
    /// Validate the phone.
    /// </summary>
    /// <param name="phone">The phone request. Use default value: {"phoneNumber":"41748596742","phoneType":1}</param>
    /// <returns>If the phone is valid.</returns>
    /// <response code="200">Validation was successful.</response>
    /// <response code="400">Validation happen with errors.</response>
    [HttpPost(PhoneRouteConstants.ValidatePhone)]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
	[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
	public async Task<bool> ValidatePhoneAsync([FromBody] Phone phone) =>
		await _phoneService.ValidatePhoneAsync(phone);
}
