using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class WaterRepository
{
	AppDbContext _dbcontext;
	public WaterRepository(AppDbContext dbContext)
	{
		_dbcontext = dbContext;
	}

	// crud what we want to do with water? 

	// "create" water
	public async Task<bool>AddWater(Water water)
	{
		await _dbcontext.AddAsync(water);

		var result = 0 < await _dbcontext.SaveChangesAsync();

		return result;
	}

}
