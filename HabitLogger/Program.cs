using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HabitLogger.Data;
using HabitLogger.Logic;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<HabitLoggerDbContext>(options =>
    options.UseSqlServer("HabitLoggerConnectionString"));

builder.Services.AddScoped<HabitMethods>();
builder.Services.AddScoped<App>();

var host = builder.Build();

host.Services.GetRequiredService<App>().Run();