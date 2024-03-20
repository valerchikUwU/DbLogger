using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLogger.Infrastructure.DataAccess.Contexts
{
    public class LogMessageConfiguration : IEntityTypeConfiguration<Domain.LogMessage>
    {
        public void Configure(EntityTypeBuilder<Domain.LogMessage> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.ThreadId);
            builder.Property(a => a.Message).IsRequired();
            builder.Property(a => a.Timestamp).HasConversion(s => s, s => DateTime.SpecifyKind(s, DateTimeKind.Utc));

        }
    }
}
