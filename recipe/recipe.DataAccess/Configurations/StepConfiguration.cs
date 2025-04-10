using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.DataAccess.Configurations
{
    public class StepConfiguration : EntityConfiguration<Step>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Step> builder)
        {
            builder.Property(x => x.StepNumber)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.HasOne(x => x.Recipe)
                   .WithMany(x => x.Steps)
                   .HasForeignKey(x => x.RecipeId)
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
