﻿using System.Threading.Tasks;
using Faculty.AuthenticationServer.Models;
using Microsoft.AspNetCore.Identity;

namespace Faculty.AuthenticationServer.Tools
{
    public class IdentityInitialize
    {
        public static async Task InitializeAsync(UserManager<CustomUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string login = "Admin12345";
            const string password = "Admin12345";
            if (await roleManager.FindByNameAsync("administrator") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("administrator"));
            }

            if (await roleManager.FindByNameAsync("employee") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("employee"));
            }

            if (await userManager.FindByNameAsync(login) == null)
            {
                var admin = new CustomUser { UserName = login };
                var result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRolesAsync(admin, new[] { "administrator", "employee" });
                }
            }
        }
    }
}