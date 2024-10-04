using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.DTO
{
    public class CreateImageDTO
    {
        public int RecipeId { get; set; }
        public List<string> Images { get; set; }
    }

    public class UpdateImageDTO : CreateImageDTO
    {
        public int Id { get; set; }
    }

    public class SearchImagesDTO : PagedSearch
    {
        public int? Id { get; set; }
        public int? RecipeId { get; set; }
        public string Path { get; set; }
    }

    public class ResponseImagesDTO
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Path { get; set; }
    }
}
