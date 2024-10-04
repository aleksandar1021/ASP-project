using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.DTO
{
    public class UserUseCasesDTO 
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }
    }

    public class SearchUserUseCasesDTO : PagedSearch
    {
        public int? UserId { get; set; }
        public int? UseCaseId { get; set; }
    }
}
