using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Workout
{
	public int Id { get; set; }
	public string Description { get; set; } = string.Empty;
	public bool WorkoutCompleted { get; set; } = false;

	// nav prop
	public int DailyLogId { get; set; }
	[ForeignKey("DailyLogId")]
	public DailyLog DailyLog { get; set; }
}
