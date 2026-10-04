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

		public async Task<DailyLog?> GetDailyLogById(int id)
		{
			var logById = await _dbContext.DailyLogs.Include(d => d.Water).Include(d => d.Workout).Include(d => d.Mood).Include(d => d.UserInfo)
				.FirstOrDefaultAsync(l => l.Id == id);

			return logById;
		}

		public async Task <bool> AddDailyLog(DailyLog dailyLog)
		{
			var mood = await _dbContext.Moods.FirstOrDefaultAsync(m => m.Id == dailyLog.MoodId);
			dailyLog.Mood = mood;

			await _dbContext.DailyLogs.AddAsync(dailyLog);

			var result = 0 < await _dbContext.SaveChangesAsync();

			return result;
		}
		public async Task<bool> UpdateDailyLog(DailyLog dailyLog)
		{
			var mood = await _dbContext.Moods.FirstOrDefaultAsync(m => m.Id == dailyLog.MoodId);
			dailyLog.Mood = mood;

			 _dbContext.DailyLogs.Update(dailyLog);

			var result = 0 < await _dbContext.SaveChangesAsync();

			return result;
		}

		public async Task <bool> DeleteLog(int id)
		{
			var logToDelete = await _dbContext.DailyLogs.FirstOrDefaultAsync(l => l.Id == id);
			if (logToDelete == null)
				return false;

			_dbContext.DailyLogs.Remove(logToDelete);

			var result = 0 < await _dbContext.SaveChangesAsync();
			return result;

		}

	}
}
