using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.DataAccess.Configurations;
using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.DataAccess.Configurations
{
    public class RatingConfiguration : EntityConfiguration<Rating>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Rating> builder)
        {
            builder.Property(x => x.RatingValue).IsRequired();

            builder.HasIndex(x => x.RatingValue).IsUnique();

        }
    }
}
