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

	public async Task<bool> CreateDailyLog(int moodId, Guid userInfoId, int waterConsumed, bool waterChecked, string workoutDesc, bool workoutChecked)
	{
		var dailyLog = new DailyLog
		{
			LogDate = DateTime.UtcNow,
			MoodId = moodId,
			UserInfoId = userInfoId
		};
		var workout = new Workout
		{
			WorkoutCompleted = workoutChecked,
			Description = workoutDesc
		};
		var water = new Water
		{
			WaterChecked = waterChecked,
			WaterConsumed = waterConsumed
		};

		dailyLog.Water = water;
		dailyLog.Workout = workout;

		var result = await _dailyLogRepository.AddDailyLog(dailyLog);

		return result;
	}

	public async Task<bool> RemoveLog(int id)
	{
		// check if user owns log ? 
		var result = await _dailyLogRepository.DeleteLog(id);

		return result;
	}

}
