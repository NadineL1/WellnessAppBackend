using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

	// crud
	[AllowAnonymous] // öppen för ALLA dailylogs - ta bort senare. implementera för admin in future?
	[HttpGet]
	public async Task<ActionResult> GetAllDailyLogs()
	{
		var allDailyLogs = await _dailyLogService.GetAllDailyLogs();
		return Ok(allDailyLogs);
	}

	[HttpGet("myDailyLogs")]
	public async Task<ActionResult> GetMyDailyLogs()
	{
		var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
		var myDailyLogs = await _dailyLogService.GetDailyLogsByUser(userId);
		return Ok(myDailyLogs);
	}

	[HttpPost("dailylogs")]
	public async Task<ActionResult<bool>> CreateDailyLog(int moodId, int workoutId, int waterId, UserInfo userInfo, int waterConsumed, bool waterChecked, string workoutDesc, bool workoutChecked)
	{
		var newDailyLog = await _dailyLogService.CreateDailyLog(moodId,workoutId, waterId,userInfo,waterConsumed,waterChecked,workoutDesc,workoutChecked);

		return Created();
	}

	[HttpDelete]
	public async Task<ActionResult<bool>> DeleteDailylog(int dailyLogId)
	{
		var success = await _dailyLogService.RemoveLog(dailyLogId);
		return Ok(success);
	}
}
