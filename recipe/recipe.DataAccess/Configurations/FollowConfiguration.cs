using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.DataAccess.Configurations;
using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.DataAccess.Configurations
{
    public class FollowConfiguration : EntityConfiguration<Follow>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Follow> builder)
        {
            builder.Property(x => x.FollowId).IsRequired();

            builder.HasOne(f => f.User)
                   .WithMany(u => u.Follows)
                   .HasForeignKey(f => f.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.FollowUser)
                    .WithMany(u => u.FollowedBy)
                    .HasForeignKey(f => f.FollowId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
