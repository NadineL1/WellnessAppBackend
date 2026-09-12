using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class DailyLog
{
	public int Id { get; set; }
	public DateTime LogDate { get; set; }
	[Required]
	public int MoodId { get; set; }
	[Required]
	public int WorkoutId{ get; set; }
	[Required]
	public int WaterId { get; set; }
	public required Guid UserInfoId { get; set; }

	// nav props
	public UserInfo UserInfo { get; set; }
	public Workout Workout { get; set; }
	public Water Water { get; set; }

}
