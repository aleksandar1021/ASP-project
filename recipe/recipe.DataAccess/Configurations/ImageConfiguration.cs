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
    public class ImageConfiguration : EntityConfiguration<Image>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.Path).IsRequired();

            builder.HasOne(x => x.Recipe)
                   .WithMany(x => x.Images)
                   .HasForeignKey(x => x.RecipeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
