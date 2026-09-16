using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
	[HttpGet("All-Dailylogs")]
	public async Task<ActionResult> GetAllDailyLogs()
	{
		var allDailyLogs = await _dailyLogService.GetAllDailyLogs();
		return Ok(allDailyLogs);
	}



}
