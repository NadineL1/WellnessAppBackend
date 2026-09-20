using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; // config to fix json circular reference problems
	});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(
	options => options.UseSqlServer(
		builder.Configuration.GetConnectionString("DefaultConnection"))
	);

builder.Services.AddIdentity<UserInfo, IdentityRole<Guid>>(
	options => options.User.RequireUniqueEmail = true
	)
	.AddEntityFrameworkStores<AppDbContext>()
	.AddDefaultTokenProviders();

builder.Services.AddScoped<DailyLogService>();
builder.Services.AddScoped<DailyLogRepository>();

builder.Services.AddAuthentication();

builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
	options.AddPolicy("FrontendDev", policy =>
	{
		policy.WithOrigins("http://localhost:5173")
		.AllowAnyHeader()
		.AllowAnyMethod();
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("FrontendDev");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
