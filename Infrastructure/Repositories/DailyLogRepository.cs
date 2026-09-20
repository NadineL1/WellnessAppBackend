using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
	public class DailyLogRepository
	{
		AppDbContext _dbContext;
		public DailyLogRepository (AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		// crud

		public async Task<List<DailyLog>> GetAllDailyLogs()
		{
			var dailyLogs = await _dbContext.DailyLogs.Include(d => d.Water).Include(d => d.Workout).Include(d => d.Mood)
				.ToListAsync();
			return dailyLogs;
		}

		public async Task<List<DailyLog>> GetDailyLogsByUser(Guid UserInfoId)
		{
			var dailyLogByUser = await _dbContext.DailyLogs.Include(d => d.Water).Include(d => d.Workout).Include(d => d.Mood)
				.Where(d => d.UserInfoId == UserInfoId)
				.ToListAsync();

			return dailyLogByUser;
		}

		public async Task <bool> AddDailyLog(DailyLog dailyLog)
		{
			await _dbContext.DailyLogs.AddAsync(dailyLog);

			var result = 0 < await _dbContext.SaveChangesAsync();

			return result;
		}

		public async Task <bool> DeleteLog(int id)
		{
			var logToDelete = await _dbContext.DailyLogs.FirstOrDefaultAsync(l => l.Id == id);

			_dbContext.DailyLogs.Remove(logToDelete);

			var result = 0 < await _dbContext.SaveChangesAsync();
			return result;

		}

	}
}
