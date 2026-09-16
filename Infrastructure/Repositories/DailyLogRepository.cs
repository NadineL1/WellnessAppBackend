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
			var dailyLogs = await _dbContext.DailyLogs.ToListAsync();
			return dailyLogs;
		}

	}
}
