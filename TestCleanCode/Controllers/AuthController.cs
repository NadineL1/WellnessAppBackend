using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TestCleanCode.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
	// add signin manager and usermanager via dependency injection
	readonly SignInManager<UserInfo> _signInManager;
	readonly UserManager<UserInfo> _userManager;

	public AuthController(SignInManager<UserInfo> signInManager, UserManager<UserInfo> userManager)
	{
		_signInManager = signInManager;
		_userManager = userManager;
	}

	// methods for register, login and logout
	[HttpPost("register")]
	public async Task<ActionResult> RegisterUser(RegisterModelDto model)
	{

		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

		var UserToAdd = new UserInfo
		{
			Id = Guid.NewGuid(),
			UserName = model.Email,
			Email = model.Email
		};

		var result = await _userManager.CreateAsync(UserToAdd, model.Password);

		if (!result.Succeeded)
			return BadRequest(result.Errors);

		return Ok("created");
	}

	[HttpPost("login")]
	public async Task<ActionResult> LoginUser(RegisterModelDto model)
	{
		if(!ModelState.IsValid)
			return BadRequest("login failed due to invalid input");

		var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

		if (user == null)
			return BadRequest("user not found");

		var loginResult = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

		return Ok(loginResult.Succeeded);
	}

	[Authorize]
	[HttpPost("logout")]
	public async Task<ActionResult> LogOut()
	{
		// check that user logged in is same that tries to logout - not nessesary! claims is already just your info, your cookie that we remove when signoutAsync
		await _signInManager.SignOutAsync();
		return Ok("Logging out"); 
	}

	public class RegisterModelDto
	{
		[Required]
		public required string Email { get; set; }

		[Required]
		public required string Password { get; set; }
	}
	

}
