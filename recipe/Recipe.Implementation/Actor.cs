﻿using Recipe.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation
{
    public class Actor : IApplicationActor
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public IEnumerable<int> AllowedUseCases { get; set; } 

    }

    
}
