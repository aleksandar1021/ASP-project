using Recipe.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation
{
    public class UnauthorizedActor : IApplicationActor
    {
        public int Id => 38;

        public string Email => "/";

        public string Username => "unauthorized";

        public string FirstName => "unauthorized";

        public string LastName => "unauthorized";

        public IEnumerable<int> AllowedUseCases => new List<int> { 1, 13, 14, 51, 50, 48, 47, 18, 46, 49, 45, 23, 22, 43, 10 };
    }
}
