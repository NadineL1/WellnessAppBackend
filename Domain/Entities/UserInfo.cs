using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class UserInfo : IdentityUser<Guid>
{
	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public int Age { get; set; }
	public DateTime Birthday { get; set; }

	// nav prop
	[JsonIgnore]
	public List<DailyLog> DailyLogs { get; set; } = [];

}