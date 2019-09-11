using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using SportsFinder.Data.Models;

namespace SportsFinder.Data

{
    public static class Seed

    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)

        {
            //adding customs roles

            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (Configuration.GetSection("SiteSettings:Admin").Exists() == false)
                return;
            var username = Configuration.GetSection("SiteSettings:Admin")["Username"];
            var password = Configuration.GetSection("SiteSettings:Admin")["Password"];
            var email = Configuration.GetSection("SiteSettings:Admin")["Email"];
            var displayName = Configuration.GetSection("SiteSettings:Admin")["displayName"];

            //Add more roles if needed here.
            string[] roleNames = { "Admin", "Member" };

            IdentityResult roleResult;
            foreach (var roleName in roleNames)

            {
                // creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // creating a super user who could maintain the web app
            var poweruser = new ApplicationUser
            {
                UserName = username,
                Email = email,
                DisplayName = displayName,
                GenderId = 1
                
            };

            var user = await UserManager.FindByNameAsync(username);
            if (user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, password);
                if (createPowerUser.Succeeded)
                {
                    // here we assign the new user the "Admin" role
                    await UserManager.AddToRoleAsync(poweruser, "Admin");
                }
            }
            else if (await UserManager.IsInRoleAsync(user, "Admin") == false)
            {
                await UserManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}