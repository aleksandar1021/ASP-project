using Recipe.Application.DTO;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.Validators
{
    public class CreateFollowValidator : BaseFollowValidator<CreateFollowDTO>
    {
        public CreateFollowValidator(RecipeContext ctx) : base(ctx)
        {
        }
    }
}
