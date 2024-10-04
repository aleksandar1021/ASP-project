using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.DTO
{
    public class CreateStepDTO 
    {
        public int RecipeId { get; set; }
        public string Description { get; set; }
    }

    public class UpdateStepDTO : CreateStepDTO
    {
        public int Id { get; set; }
    }

    public class ResponseStepDTO
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; }
    }

    public class SearchStepDTO : PagedSearch
    {
        public int? Id { get; set; }
        public int? RecipeId { get; set; }
        public int? StepNumber { get; set; }
        public string Description { get; set; }
    }
}
