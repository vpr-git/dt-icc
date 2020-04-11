using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace ServerApp.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "admin";
        private const string adminPassword = "password";
        private const string adminRole = "Administrator";
        
        public static async void SeedDataBase(IApplicationBuilder app)
        {
            GetAppService<IdentityDataContext>(app).Database.Migrate();
            UserManager<IdentityUser> userManager = GetAppService<UserManager<IdentityUser>>(app);
            RoleManager<IdentityRole> roleManager = GetAppService<RoleManager<IdentityRole>>(app);

            IdentityRole role = await roleManager.FindByNameAsync(adminRole);
            IdentityUser user = await userManager.FindByNameAsync(adminUser);

            if (role == null)
            {
                user = new IdentityUser(adminUser);
                IdentityResult result = await userManager.CreateAsync(user,adminPassword);
                if (!result.Succeeded)
                {
                    throw new Exception("Cannot crate user: " + result.Errors.FirstOrDefault());
                }
            }

            if (!await userManager.IsInRoleAsync(user, adminRole))
            {
                IdentityResult result = await userManager.AddToRoleAsync(user,adminRole);
                if (!result.Succeeded)
                {
                    throw new Exception("Cannot add user to role: " + result.Errors.FirstOrDefault());

                }
            }
        }

        private static T GetAppService<T>(IApplicationBuilder app)
        {
            return app.ApplicationServices.GetRequiredService<T>();
        }
    }
}
