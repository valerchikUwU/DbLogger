using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace DbLogger.Infrastructure.DataAccess
{
    public class LoggerDbContext : DbContext
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="LoggerDbContext"/>.
        /// </summary>
        public LoggerDbContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Метод для настройки модели
        /// </summary>
        /// <param name="modelBuilder">Построитель, используемый для создания модели для этого контекста</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), t => t.GetInterfaces().Any(i =>
                i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
        }
    }
}
