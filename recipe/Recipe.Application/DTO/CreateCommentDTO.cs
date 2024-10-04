using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.DTO
{
    public class CreateCommentDTO
    {
        public int? ParentId { get; set; }
        public string Text { get; set; }
        public int RecipeId { get; set; }
        public List<int> ChildsIds { get; set; }
    }

    public class UpdateCommentDTO : CreateCommentDTO
    {
        public int Id { get; set; }
    }
}
