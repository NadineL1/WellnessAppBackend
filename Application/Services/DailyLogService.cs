using Domain.Entities;
using Infrastructure.Repositories;

namespace Application.Services;

public class DailyLogService
{
	DailyLogRepository _dailyLogRepository;
	public DailyLogService(DailyLogRepository dailyLogRepository)
	{
		_dailyLogRepository = dailyLogRepository;
	}

	// crud
	 

	// ha denna öppen till att börja med :)
	public async Task<List<DailyLog>> GetAllDailyLogs()
	{
		var dailyLogs = await _dailyLogRepository.GetAllDailyLogs();
		return dailyLogs;
	}

	public async Task<List<DailyLog>> GetDailyLogsByUser(Guid userId)
	{
		var dailyLogsByUser = await _dailyLogRepository.GetDailyLogsByUser(userId);

		return dailyLogsByUser;
	}

}
