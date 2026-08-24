using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Water
{
	public int Id { get; set; }
	public int WaterConsumed { get; set; }
	public bool WaterChecked { get; set; } = false;

	[JsonIgnore]
	public List<DailyLog> DailyLogs { get; set; } = [];

}

