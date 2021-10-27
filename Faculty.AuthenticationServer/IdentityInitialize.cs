﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Faculty.AuthenticationServer
{
    public class IdentityInitialize
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
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
                var admin = new IdentityUser { UserName = login };
                var result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRolesAsync(admin, new[] { "administrator", "employee" });
                }
            }
        }
    }
}