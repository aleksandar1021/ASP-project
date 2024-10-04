using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.DataAccess.Configurations
{
    public class ErrorLogsConfiguration : IEntityTypeConfiguration<ErrorLog>
    {
        public void Configure(EntityTypeBuilder<ErrorLog> builder)
        {
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Message).IsRequired();

            builder.Property(x => x.StrackTrace).IsRequired();

            builder.HasKey(x => x.Id);
        }
    }
}
