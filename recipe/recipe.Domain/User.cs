using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Follow> Follows { get; set; } = new HashSet<Follow>();
        public virtual ICollection<Follow> FollowedBy { get; set; } = new HashSet<Follow>();

        public virtual ICollection<Recipes> Recipes { get; set; } = new HashSet<Recipes>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<UserUseCase> UserUseCases { get; set; } = new HashSet<UserUseCase>();
        public virtual ICollection<RecipeRating> RecipeRatings { get; set; } = new HashSet<RecipeRating>();
    }
}
