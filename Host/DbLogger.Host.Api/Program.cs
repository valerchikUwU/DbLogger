using DbLogger.Application.AppData.Repository;
using DbLogger.Application.AppData.Service;
using DbLogger.Infrastructure.DataAccess;
using DbLogger.Infrastructure.DataAccess.Contexts;
using DbLogger.Infrastructure.DataAccess.Interfaces;
using DbLogger.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDbContextOptionsConfigurator<LoggerDbContext>,LoggerDbContextConfiguration>();


builder.Services.AddDbContext<LoggerDbContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
    ((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<LoggerDbContext>>()
        .Configure((DbContextOptionsBuilder<LoggerDbContext>)dbOptions)));

builder.Services.AddScoped((Func<IServiceProvider, DbContext>)(sp => sp.GetRequiredService<LoggerDbContext>()));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ILogMessageRepository, LogMessageRepository>();

builder.Services.AddScoped<ILogService, LogService>();



builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
