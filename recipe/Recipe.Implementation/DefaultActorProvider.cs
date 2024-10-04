using Recipe.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation
{
    public class DefaultActorProvider : IApplicationActorProvider
    {
        public IApplicationActor GetActor()
        {
            return new Actor
            {
                Email = "actor",
                Username = "actor",
                Id = 0,
                FirstName = "Actor",
                LastName = "Actor"
            };
        }
    }
}
