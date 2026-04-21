using Microsoft.AspNetCore.Identity;
using Perfume.Models;

namespace Perfume.Data
{
    public class DatabaseSeeder
    {

        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            string[] roles = { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            string adminMail = "admin@gmail.com";
            var adminUser = await userManager.FindByNameAsync(adminMail);

            if (adminUser == null)
            {
                var newAdmin = new AppUser
                {
                    UserName = adminMail,
                    Email = adminMail,
                    Name = "Sistem",
                    Surname = "Yönetici",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(newAdmin, "Admin123.");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                }
            }


        }
    }
}
