using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Survey.Entity.Concrete
{
    public class User : IdentityUser
    {
        public ICollection<Answer> Answers{ get; set; }
    }
}