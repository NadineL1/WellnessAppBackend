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
	public async Task<ActionResult> UpdateDailyLog(UpdateDailyLogDto updateDailyLogDto)
	{
		if (!User.TryGetUserId(out var userId))
		{
			return Unauthorized();
		}
		var updateDailyLog = await _dailyLogService.UpdateDailyLog(userId, updateDailyLogDto);

		return Created();
	}

	[HttpDelete]
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



