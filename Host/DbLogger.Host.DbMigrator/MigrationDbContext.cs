using DbLogger.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLogger.Host.DbMigrator
{
    public class MigrationDbContext : LoggerDbContext
    {
        public MigrationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
