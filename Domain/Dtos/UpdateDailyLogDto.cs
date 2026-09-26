namespace Domain.Dtos
{
		public class UpdateDailyLogDto
		{
			  public int Id { get; set; }
			  public int MoodId { get; set; }
			  public bool WaterChecked { get; set; }
			  public int WaterConsumed { get; set; }
			  public bool WorkoutChecked { get; set; }
			  public string WorkoutDesc { get; set; } = string.Empty;
		}
}
