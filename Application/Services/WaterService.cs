using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace Application.Services;

public class WaterService
{
	// dependency injection of water repository
	WaterRepository _waterRepository;
	public WaterService(WaterRepository waterRepository)
	{
		_waterRepository = waterRepository;
	}

	// "create" water
	public async Task<bool> AddWater(int id, int waterConsumed, bool waterChecked, DailyLog dailyLog)
	{
		var water = new Water
		{
			Id = id,
			WaterConsumed = waterConsumed,
			WaterChecked = waterChecked,
			DailyLogId = dailyLog.Id,
			DailyLog = dailyLog
		};
		var result = await _waterRepository.AddWater(water);

		return result;
	}

}
