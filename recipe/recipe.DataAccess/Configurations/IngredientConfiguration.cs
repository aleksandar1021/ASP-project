using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.DataAccess.Configurations
{
    public class IngredientConfiguration : NamedEntityConfiguration<Ingredient>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Ingredient> builder)
        {
            
        }
    }
}
