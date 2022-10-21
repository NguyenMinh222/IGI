using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_053503_NGUYEN2.Entities;

namespace WEB_053503_NGUYEN2.Data
{
    public class DbInitializer
    {
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

            if (!dbContext.CarGroups.Any()) {
                dbContext.CarGroups.AddRange(
                    new List<CarGroup>()
                    {
                        new CarGroup { CarGroupName = "Электрический" },
                        new CarGroup { CarGroupName = "Бизнес-класс" },
                        new CarGroup { CarGroupName = "Кроссовер" },
                        new CarGroup { CarGroupName = "Мини" },
                        new CarGroup { CarGroupName = "Спорткар" }
                    }
                    ) ;
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Cars.Any())
            {
                dbContext.Cars.AddRange(
                new List<Car>
                {
                    new Car
                    {
                        CarName = "Tesla",
                        Description = "Электрический автомобиль",
                        Price = 130000,
                        CarGroupId = 1, 
                        Image = "Tesla.jpg"
                    },
                    new Car
                    {
                        CarName = "Cadillac",
                        Description = "Очень комфортный автомобиль",
                        Price = 150000,
                        CarGroupId = 2,
                        Image = "cadillac.jpg"
                    },
                    new Car
                    {
                        CarName = "Huyndai",
                        Description = "Для тез кто любит машины побольше",
                        Price = 70000,
                        CarGroupId = 3, 
                        Image = "crossover.jpg"
                    },
                    new Car
                    {
                        CarName = "Mini Cooper",
                        Description = "Для двух человек",
                        Price = 55000,
                        CarGroupId = 4, Image = "Cooper.jpg"
                    },
                    new Car
                    {
                        CarName = "Ferrari",
                        Description = "Для тех кто любит скорость",
                        Price = 223000, 
                        CarGroupId = 5, 
                        Image = "sport.jpg"
                    }
                });
                await dbContext.SaveChangesAsync();
            }

        }

    }

}
