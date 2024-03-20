using DbLogger.Infrastructure.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLogger.Infrastructure.DataAccess
{
    public class LoggerDbContextConfiguration : IDbContextOptionsConfigurator<LoggerDbContext>
    {
        private const string MSSQLConnectionStringName = "LoggerDb";

        private readonly IConfiguration _configuration;

        public LoggerDbContextConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Подключение к БД
        /// </summary>
        /// <param name="options"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void Configure(DbContextOptionsBuilder<LoggerDbContext> options)
        {
            var connectionString = _configuration.GetConnectionString(MSSQLConnectionStringName);
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    $"Не найдена строка подключения с именем '{MSSQLConnectionStringName}'");
            }
            options.UseSqlServer(connectionString);
        }
    }
}
