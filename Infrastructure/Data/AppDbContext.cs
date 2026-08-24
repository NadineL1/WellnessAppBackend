using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : IdentityDbContext<UserInfo, IdentityRole<Guid>,Guid>
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


	public DbSet<DailyLog> DailyLogs { get; set; }

	public DbSet<Workout> Workouts { get; set; }

	public DbSet<Water> Waters { get; set; }
}
