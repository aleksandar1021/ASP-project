using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.DataAccess.Configurations
{
    public class RecipeIngredientConfiguration : EntityConfiguration<RecipeIngredient>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.Property(x => x.Quantity).HasMaxLength(200);

            builder.HasOne(x => x.Ingredient)
                   .WithMany(x => x.RecipeIngredients)
                   .HasForeignKey(x => x.IngredientId);

            builder.HasOne(x => x.Recipe)
                   .WithMany(x => x.RecipeIngredients)
                   .HasForeignKey(x => x.RecipeId);
        }
    }
}
