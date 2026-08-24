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

		builder.Entity<Mood>().HasData(
				new Mood { Id = 1, Description = "Very Bad" },
				new Mood { Id = 2, Description = "Bad" },
				new Mood { Id = 3, Description = "Okay" },
				new Mood { Id = 4, Description = "Good" },
				new Mood { Id = 5, Description = "Fantastic" }
			);
	}
}
