using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain
{
    public class Follow : Entity
    {
        public int UserId { get; set; }
        public int FollowId { get; set;}

        public virtual User User { get; set; }
        public virtual User FollowUser { get; set; }
    }
}
