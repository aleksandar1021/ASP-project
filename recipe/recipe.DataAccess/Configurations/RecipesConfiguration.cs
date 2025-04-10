using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Recipe.DataAccess.Configurations
{
    public class RecipesConfiguration : EntityConfiguration<Recipes>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Recipes> builder)
        {
            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Description)
                   .HasMaxLength(250);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Recipes)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Recipes)
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.Title);
        }
    }
}
