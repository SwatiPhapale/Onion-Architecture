using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
namespace RepoProject.Core.Entities
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
