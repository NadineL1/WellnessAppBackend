using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : IdentityDbContext<UserInfo, IdentityRole<Guid>,Guid>
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	public DbSet<Mood> Moods { get; set; }
	public DbSet<DailyLog> DailyLogs { get; set; }
	public DbSet<Workout> Workouts { get; set; }
	public DbSet<Water> Waters { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);


		var user1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
		var user2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");

		builder.Entity<UserInfo>().HasData(
			new UserInfo
			{
				Id = user1Id,
				UserName = "hej@info.com",
				NormalizedUserName = "HEJ@INFO.COM",
				Email = "hej@info.com",
				NormalizedEmail = "HEJ@INFO.COM",
				SecurityStamp = "00000000-0000-0000-0000-000000000001",
				ConcurrencyStamp = "00000000-0000-0000-0000-000000000001",
				FirstName = "Anna",
				LastName = "Andersson",
				Age = 28,
				Birthday = new DateOnly(1997, 10, 20)
			},
			new UserInfo
			{
				Id = user2Id,
				UserName = "tja@info.com",
				NormalizedUserName = "TJA@INFO.COM",
				Email = "tja@info.com",
				NormalizedEmail = "TJA@INFO.COM",
				SecurityStamp = "00000000-0000-0000-0000-000000000002",
				ConcurrencyStamp = "00000000-0000-0000-0000-000000000002",
				FirstName = "Bertil",
				LastName = "Bertilsson",
				Age = 25,
				Birthday = new DateOnly(2005, 12, 10)
			}
		);

		builder.Entity<Mood>().HasData(
				new Mood { Id = 1, Description = "Very Bad" },
				new Mood { Id = 2, Description = "Bad" },
				new Mood { Id = 3, Description = "Okay" },
				new Mood { Id = 4, Description = "Good" },
				new Mood { Id = 5, Description = "Fantastic" }
			);

		builder.Entity<DailyLog>().HasData(
			new DailyLog { Id = 1, UserInfoId= user1Id, LogDate = new DateTime(2026,09,10), MoodId = 1, WaterId =4, WorkoutId = 1},
			new DailyLog { Id = 2, UserInfoId = user1Id, LogDate = new DateTime(2026,09,11), MoodId = 5, WaterId = 3, WorkoutId = 2 },
			new DailyLog { Id = 3, UserInfoId = user2Id, LogDate = new DateTime(2026, 09, 10), MoodId = 5, WaterId = 2, WorkoutId = 3},
			new DailyLog { Id = 4, UserInfoId = user2Id, LogDate = new DateTime(2026,09,11), MoodId = 4, WaterId = 1, WorkoutId = 4}
			);

		builder.Entity<Workout>().HasData(
			new Workout { Id= 1, DailyLogId= 1, Description="Walk", WorkoutCompleted = true  },
			new Workout { Id=2, DailyLogId=2, Description="Yoga", WorkoutCompleted =true},
			new Workout { Id=3, DailyLogId =3, Description ="Running", WorkoutCompleted = true},
			new Workout { Id = 4, DailyLogId=4, Description = "Gym", WorkoutCompleted = true}
			);

		builder.Entity<Water>().HasData(
			new Water { Id = 1, DailyLogId=1, WaterChecked= true, WaterConsumed=3},
			new Water { Id = 2, DailyLogId = 2, WaterChecked = true, WaterConsumed= 5},
			new Water { Id = 3, DailyLogId = 3, WaterChecked= false, WaterConsumed =0},
			new Water { Id=4, DailyLogId = 4, WaterChecked= true, WaterConsumed = 10}
			);

	}
}
