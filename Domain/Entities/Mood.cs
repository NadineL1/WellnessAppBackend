using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Mood
{
	public int Id { get; set; }
	public string Description { get; set; } = string.Empty;

	[JsonIgnore]
	public List<DailyLog> DailyLogs { get; set; } = [];
}
