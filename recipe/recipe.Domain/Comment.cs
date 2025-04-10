using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain
{
    public class Comment : Entity
    {
        public int? ParentId { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }

        public virtual Comment Parent { get; set; }
        public virtual ICollection<Comment> Children { get; set; }
        public virtual Recipes Recipe { get; set; }
        public virtual User User { get; set; }
    }
}
