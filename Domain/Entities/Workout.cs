using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Workout
{
	public int Id { get; set; }
	public string Description { get; set; } = string.Empty;
	public bool WorkoutCompleted { get; set; }

	[JsonIgnore]
	public List<DailyLog> DailyLogs { get; set; } = [];
}
