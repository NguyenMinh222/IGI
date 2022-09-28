using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_053503_NGUYEN2.Entities;

namespace WEB_053503_NGUYEN2.Data
{
    public class DbInitializer
    {
        //public static void Initializer (ApplicationDbContext dbContext, UserManager<IdentityUser> usermanager, RoleManager<IdentityRole> rolemanager)
        //{ 

        //}
        public static async Task InitializeAs(ApplicationDbContext dbContext, UserManager<ApplicationUser> usermanager, RoleManager<IdentityRole> rolemanager)
        {
            dbContext.Database.EnsureCreated();

            if (!dbContext.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };

                await rolemanager.CreateAsync(roleAdmin);
            }

            if (!dbContext.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await usermanager.CreateAsync(user, "123456");

                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@gmail.com"
                };
                await usermanager.CreateAsync(admin, "123456");
                admin = await usermanager.FindByEmailAsync("admin@gmail.com");
                await usermanager.AddToRoleAsync(admin, "admin");
            }

        }

    }

}
