using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Water
{
	public int Id { get; set; }
	[Required]
	public int WaterConsumed { get; set; }
	public bool WaterChecked { get; set; } = false;

	// nav prop
	public int DailyLogId { get; set; }
	[ForeignKey("DailyLogId")]
	public DailyLog DailyLog { get; set; }

}

