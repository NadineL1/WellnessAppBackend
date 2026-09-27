using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Domain.Dtos;

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
		var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
		var myDailyLogs = await _dailyLogService.GetDailyLogsByUser(userId);
		return Ok(myDailyLogs);
	}

	[HttpPost]
	public async Task<ActionResult<bool>> CreateDailyLog(DailyLogDto dailyLogDto)
	{
		var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
		var newDailyLog = await _dailyLogService.CreateDailyLog(userId, dailyLogDto);

		return Created();
	}

	[HttpPut]
	public async Task<ActionResult> UpdateDailyLog(UpdateDailyLogDto updateDailyLogDto)
	{
		var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
		var updateDailyLog = await _dailyLogService.UpdateDailyLog(userId, updateDailyLogDto);

		return Created();
	}

	[HttpDelete]
	public async Task<ActionResult<bool>> DeleteDailylog(int dailyLogId)
	{
		var success = await _dailyLogService.RemoveLog(dailyLogId);
		return NoContent();
	}
}



