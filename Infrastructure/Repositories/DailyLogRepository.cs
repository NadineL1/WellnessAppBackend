using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
	public class DailyLogRepository
	{
		AppDbContext _dbContext;
		public DailyLogRepository (AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

	}
}
