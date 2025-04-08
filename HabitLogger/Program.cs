using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HabitLogger.Data;
using HabitLogger.Logic;
using HabitLogger.Repositories;
using HabitLogger.Mappings;
using Microsoft.Extensions.Logging;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.ClearProviders(); // Убираем все стандартные провайдеры логирования

builder.Services.AddDbContext<HabitLoggerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HabitLoggerConnectionString")));


builder.Services.AddScoped<HabitMethods>();
builder.Services.AddScoped<App>();
builder.Services.AddScoped<IHabitRepository, SQLHabitRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var host = builder.Build();
host.Services.GetRequiredService<App>().Run();