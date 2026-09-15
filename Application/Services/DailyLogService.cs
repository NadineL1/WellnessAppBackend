using Infrastructure.Repositories;

namespace Application.Services;

public class DailyLogService
{
	DailyLogRepository _dailyLogRepository;
	public DailyLogService(DailyLogRepository dailyLogRepository)
	{
		_dailyLogRepository = dailyLogRepository;
	}



}
