using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class UserInfo : IdentityUser<Guid>
{
	[Required]
	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	[Required]
	public int Age { get; set; }
	public DateOnly Birthday { get; set; }

	// nav prop
	public List<DailyLog> DailyLogs { get; set; } = [];
}