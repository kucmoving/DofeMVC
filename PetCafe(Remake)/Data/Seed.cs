using Microsoft.AspNetCore.Identity;
using PetCafe_Remake_.Models;
using PetCafe_Remake_.Models.Data.Enum;

namespace PetCafe_Remake_.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Dogs.Any())
                {
                    context.Dogs.AddRange(new List<Dog>()
                    {
                        new Dog()
                        {
                            DogName = "NuNu",
                            Image = "https://freerangestock.com/thumbnail/123781/pembroke-welsh-corgi.jpg",
                            Introduction = "This is my first Dog",
                            DogCategory = DogCategory.HerdingGroup,
                            VisitTime = new VisitTime()
                            {
                                Day = "Sunday",
                                TimeFrame = "Afternoon"
                            }
                         },
                        new Dog()
                        {
                            DogName = "Pinky",
                            Image = "https://freerangestock.com/thumbnail/89960/photo.jpg",
                            Introduction = "He loves to eat",
                            DogCategory = DogCategory.HoundGroup,
                            VisitTime = new VisitTime()
                            {
                                Day = "Sunday",
                                TimeFrame = "Afternoon"
                            }
                         },
                        new Dog()
                        {
                            DogName = "Sunny",
                            Image = "https://freerangestock.com/thumbnail/41954/photo.jpg",
                            Introduction = "He is a nice dog",
                            DogCategory = DogCategory.NonSportingGroup,
                            VisitTime = new VisitTime()
                            {
                                Day = "Monday",
                                TimeFrame = "Morning"
                            }
                         }
                    });
                    context.SaveChanges();
                }
                //Races
                if (!context.Events.Any())
                {
                    context.Events.AddRange(new List<Event>()
                    {
                        new Event()
                        {
                            EventName = "Cooking PaPa",
                            Image = "https://images.unsplash.com/photo-1556911220-e15b29be8c8f?crop=entropy&cs=tinysrgb&fm=jpg&ixlib=rb-1.2.1&q=80&raw_url=true&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=2070",
                            Introduction = "This is Women day. Daddies and brothers will serve us but hope that they can make something 'eatable'. ",
                            EventCategory = EventCategory.Family,
                            Region = "London",
                            EventTime = new DateTime(2022, 12, 25)
                        },
                        new Event()
                        {
                            EventName = "Dog Adoption 2022",
                            Image = "https://images.pexels.com/photos/4861347/pexels-photo-4861347.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                            Introduction = "We will cooperate with other organizations to host adoption events",
                            EventCategory = EventCategory.Sport,
                            Region = "Manchester",
                            EventTime = new DateTime(2022, 11, 25)
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                string adminUserEmail = "admin@admin.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "IamAdmin",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        VisitTime = new VisitTime()
                        {
                            Day = "Sunday",
                            TimeFrame = "Afternoon",
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "1234@Qwer.com");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@user.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "IamUser",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        VisitTime = new VisitTime()
                        {
                            Day = "Friday",
                            TimeFrame = "Morning",
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "1234@Qwer.com");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}