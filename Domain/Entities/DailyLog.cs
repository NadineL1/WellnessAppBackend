using System.Text.Json.Serialization;

namespace Domain.Entities;

public class DailyLog
{
	public int Id { get; set; }
	public DateTime LogDate { get; set; }

	public int MoodId { get; set; }
	public int WorkoutId{ get; set; }
	public int WaterId { get; set; }
	public Guid UserInfoId { get; set; }
	[JsonIgnore]
	public UserInfo UserInfo { get; set; } = new UserInfo();

}
