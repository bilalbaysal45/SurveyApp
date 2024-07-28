using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Survey.MVC.Areas.Admin.Models
{
    public class UsersWithRoles
    {
        public IdentityUser User { get; set; }
        public IdentityRole Role { get; set; }
    }
}