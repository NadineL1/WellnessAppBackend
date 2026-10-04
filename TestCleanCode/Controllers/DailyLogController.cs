using Application.Services;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestCleanCode.Helpers;

namespace TestCleanCode.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DailyLogController : ControllerBase
{
	UserManager<UserInfo> _userInfo;
	DailyLogService _dailyLogService;

	public DailyLogController(UserManager<UserInfo> userInfo, DailyLogService dailyLogService)
	{
		_userInfo = userInfo;
		_dailyLogService = dailyLogService;
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status401Unauthorized)]
	public async Task<ActionResult> GetMyDailyLogs()
	{
		if (!User.TryGetUserId(out var userId))
		{
			return Unauthorized();
		}

		var myDailyLogs = await _dailyLogService.GetDailyLogsByUser(userId);
		return Ok(myDailyLogs);
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status401Unauthorized)]
	public async Task<ActionResult<bool>> CreateDailyLog(DailyLogDto dailyLogDto)
	{
		if (!User.TryGetUserId(out var userId))
		{
			return Unauthorized();
		}
		var newDailyLog = await _dailyLogService.CreateDailyLog(userId, dailyLogDto);

		return Created();
	}

	[HttpPut]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status401Unauthorized)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult> UpdateDailyLog(UpdateDailyLogDto updateDailyLogDto)
	{
		if (!User.TryGetUserId(out var userId))
		{
			return Unauthorized();
		}

		if(updateDailyLogDto.Id <= 0)
		{
			return BadRequest();
		}

		var updateDailyLog = await _dailyLogService.UpdateDailyLog(userId, updateDailyLogDto);

		return Created();
	}

	[HttpDelete]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status401Unauthorized)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<bool>> DeleteDailylog(int dailyLogId)
	{
		if (!User.TryGetUserId(out var userId))
		{
			return Unauthorized();
		}
		var success = await _dailyLogService.RemoveLog(dailyLogId);
		return NoContent();
	}
}



