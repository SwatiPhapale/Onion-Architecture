using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace RepoProject.Core.Entities
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}
