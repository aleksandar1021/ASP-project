using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases
{
    public class EfUseCase
    {
        private readonly RecipeContext _context;

        protected EfUseCase(RecipeContext context)
        {
            _context = context;
        }

        protected RecipeContext Context => _context;
    }
}
