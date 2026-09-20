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

	public async Task<bool> CreateDailyLog(int moodId, int workoutId, int waterId, UserInfo userInfo, int waterConsumed, bool waterChecked, string workoutDesc, bool workoutChecked)
	{
		var dailyLog = new DailyLog
		{
			LogDate = DateTime.UtcNow,
			MoodId = moodId,
			WorkoutId = workoutId,
			WaterId = waterId,
			UserInfo = userInfo,
			UserInfoId = userInfo.Id
		};
		var workout = new Workout
		{
			Id = waterId,
			WorkoutCompleted = workoutChecked,
			Description = workoutDesc
		};
		var water = new Water
		{
			Id = waterId,
			WaterChecked = waterChecked,
			WaterConsumed = waterConsumed
		};

		var result = await _dailyLogRepository.AddDailyLog(dailyLog, workout, water);

		return result;
	}

	public async Task<bool> RemoveLog(int id)
	{
		// check if user owns log ? 
		var result = await _dailyLogRepository.DeleteLog(id);

		return result;
	}

}
