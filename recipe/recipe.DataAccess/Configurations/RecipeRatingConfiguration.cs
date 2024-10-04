using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.DataAccess.Configurations
{
    public class RecipeRatingConfiguration : EntityConfiguration<RecipeRating>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<RecipeRating> builder)
        {
            builder.HasOne(x => x.Rating)
                   .WithMany(x => x.RecipeRatings)
                   .HasForeignKey(x => x.RatingId);

            builder.HasOne(x => x.Recipe)
                   .WithMany(x => x.RecipeRatings)
                   .HasForeignKey(x => x.RecipeId);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.RecipeRatings)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
