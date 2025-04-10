using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.DTO
{
    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public List<int> ChildIds { get; set; }
    }
}
