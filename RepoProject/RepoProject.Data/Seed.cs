using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using RepoProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoProject.Data
{
    public class Seed
    {
        public static void SeedUsers(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (!userManager.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);

                //create some roles
                var roles = new List<Role>
                {
                    new Role{Name = "Admin" },
                    new Role{Name = "Manager" },
                    new Role{Name = "Employee" },
                    new Role{Name = "EndUser" }
                };
                foreach (var role in roles)
                {
                    roleManager.CreateAsync(role).Wait();
                }

                foreach (var user1 in users)
                {
                    userManager.CreateAsync(user1, "password").Wait();
                    userManager.AddToRoleAsync(user1, "Manager");
                }

                //Create admin user 
                var adminUser = new User
                {
                    UserName = "Admin"
                };

                var result = userManager.CreateAsync(adminUser, "password").Result;

                if (result.Succeeded)
                {
                    var admin = userManager.FindByNameAsync("Admin").Result;
                    userManager.AddToRolesAsync(admin, new[] { "Admin", "Manager" });
                }

            }
        }
    }
}
