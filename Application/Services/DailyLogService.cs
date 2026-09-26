using Domain.Entities;
using Infrastructure.Repositories;
using Domain.Dtos;

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

	public async Task<bool> CreateDailyLog(Guid userId, DailyLogDto dailyLogDto)
	{
		var dailyLog = new DailyLog
		{
			LogDate = DateTime.UtcNow,
			MoodId = dailyLogDto.MoodId,
			UserInfoId = userId
		};
		var workout = new Workout
		{
			WorkoutCompleted = dailyLogDto.WorkoutChecked,
			Description = dailyLogDto.WorkoutDesc
		};
		var water = new Water
		{
			WaterChecked = dailyLogDto.WaterChecked,
			WaterConsumed = dailyLogDto.WaterConsumed
		};

		dailyLog.Water = water;
		dailyLog.Workout = workout;

		var result = await _dailyLogRepository.AddDailyLog(dailyLog);

		return result;
	}
	public async Task<bool> UpdateDailyLog(Guid userId, UpdateDailyLogDto updateDailyLogDto)
	{

		var currrentDailyLog = await _dailyLogRepository.GetDailyLogById(updateDailyLogDto.Id);
		if (currrentDailyLog is null)
			return false;

		currrentDailyLog.MoodId = updateDailyLogDto.MoodId;
		currrentDailyLog.Workout.WorkoutCompleted = updateDailyLogDto.WorkoutChecked;
		currrentDailyLog.Workout.Description = updateDailyLogDto.WorkoutDesc;
		currrentDailyLog.Water.WaterChecked = updateDailyLogDto.WaterChecked;
		currrentDailyLog.Water.WaterConsumed = updateDailyLogDto.WaterConsumed;

		var result = await _dailyLogRepository.UpdateDailyLog(currrentDailyLog);

		return result;
	}

	public async Task<bool> RemoveLog(int id)
	{
		var result = await _dailyLogRepository.DeleteLog(id);
		return result;
	}

}
