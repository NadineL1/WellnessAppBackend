using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TestCleanCode.Controllers;

// fix : water är child till daily log inte direkt till user

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class WaterController : ControllerBase
{
	WaterService _waterService;
	UserManager<UserInfo> _userManager;
	public WaterController(WaterService waterService, UserManager<UserInfo> userManager )
	{
		_waterService = waterService;
		_userManager = userManager;
	}

	/*[HttpPost]
	public async Task<ActionResult<bool>> AddWater(int id, int waterConsumed, bool waterChecked)
	{
		var success = await _waterService.AddWater(id, waterConsumed, waterChecked);
		if(!success)
		{
			return BadRequest();
		}

		return Ok(success);
	}	*/

}
