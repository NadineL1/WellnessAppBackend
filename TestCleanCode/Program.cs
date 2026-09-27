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
		builder.Configuration.GetConnectionString("PublishConnectionstring"))
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

builder.Services.ConfigureApplicationCookie(options =>
{
	options.Cookie.SameSite = SameSiteMode.None;
	options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
	options.Events.OnRedirectToLogin = context =>
	{
		context.Response.StatusCode = StatusCodes.Status401Unauthorized;
		return Task.CompletedTask;
	};

	options.Events.OnRedirectToAccessDenied = context =>
	{
		context.Response.StatusCode = StatusCodes.Status403Forbidden;
		return Task.CompletedTask;
	};
});

builder.Services.AddCors(options =>
{
	options.AddPolicy("FrontendDev", policy =>
	{
		policy.WithOrigins("https://wellnessappfrontend-e8gpfpbkace8cges.swedencentral-01.azurewebsites.net/")
		.AllowAnyHeader()
		.AllowAnyMethod()
		.AllowCredentials();
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
