using FluentValidation.API.Constants.RouteConstants;
using FluentValidation.API.Entities;
using FluentValidation.API.Interfaces.Services;
using FluentValidation.API.Settings.NotificationSettings;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

	public PersonController(IPersonService personService)
	{
		_personService = personService;
	}

    /// <summary>
    /// Validate the person.
    /// </summary>
    /// <param name="person">The person request. Use default value: {"firstName":"joao","lastName":"souza","age":19,"birthDate":"2004-01-27","email":"joaoasouza982@gmail.com","cpf":"86856160003","address":{"zipCode":"66910150","street":"Avenida Beira-Mar","complement":"Casa 5","number":"123","district":"Vila (Mosqueiro)","city":"Belém","state":"PA"},"phones":[{"phoneNumber":"41998574163","phoneType":1},{"phoneNumber":"41997474163","phoneType":1}],"skills":[{"name":"Csharp","category":1,"experienceYears":2},{"name":".NET","category":1,"experienceYears":2}]}</param>
    /// <returns>If the person is valid.</returns>
    /// <response code="200">Validation was successful.</response>
    /// <response code="400">Validation happen with errors.</response>
    [HttpPost(PersonRouteConstants.ValidatePerson)]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
	[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
	public async Task<bool> ValidatePersonAsync([FromBody] Person person) =>
		await _personService.ValidatePersonAsync(person);
}
