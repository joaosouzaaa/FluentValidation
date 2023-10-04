using FluentValidation.API.Constants.RouteConstants;
using FluentValidation.API.Entities;
using FluentValidation.API.Interfaces.Services;
using FluentValidation.API.Settings.NotificationSettings;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class SkillController : ControllerBase
{
    private readonly ISkillService _skillService;

	public SkillController(ISkillService skillService)
	{
		_skillService = skillService;
	}

    /// <summary>
    /// Validate the skill
    /// </summary>
    /// <param name="skill">The skill request. Use default value: {"name":".NET","category":1,"experienceYears":2}</param>
    /// <returns>If the skill is valid.</returns>
	/// <response code="200">Validation was successful.</response>
    /// <response code="400">Validation happen with errors.</response>
    [HttpPost(SkillRouteConstants.ValidateSkill)]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
	[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
	public async Task<bool> ValidateSkillAsync([FromBody] Skill skill) =>
		await _skillService.ValidateSkillAsync(skill);
}
