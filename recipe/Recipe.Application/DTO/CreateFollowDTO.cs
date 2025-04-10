using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.DTO
{
    public class CreateFollowDTO
    {
        public int UserId { get; set; }
    }

    public class UpdateFollowDTO : CreateFollowDTO
    {
        public int Id { get; set; }
    }

    public class ResponseFollowsDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FollowedId { get; set; }
    }

    public class SearchFollowsDTO : PagedSearch
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int? FollowedId { get; set; }
    }
}
