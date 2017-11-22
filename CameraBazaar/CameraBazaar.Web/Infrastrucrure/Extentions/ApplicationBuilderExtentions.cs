using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using CameraBazaar.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CameraBazaar.Data.Models;

namespace CameraBazaar.Web.Infrastrucrure.Extentions
{

    public static class ApplicationBuilderExtentions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<CameraBazaarDbContext>()
                .Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task.Run(async () =>
                {
                    var roleName = GlobalConstrants.AdministratorRole;

                    var roleExists = await roleManager.RoleExistsAsync(roleName);

                    if (!roleExists)
                    {
                        var result = await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = roleName
                        });
                    }

                    var adminUser = await userManager.FindByNameAsync(roleName);

                    if (adminUser == null)
                    {
                        adminUser = new User
                        {
                            Email = "admin@admin.com",
                            UserName = "admin@admin.com"
                        };

                      var   adminUsertwo = new User
                        {
                            Email = "admin2@admin.com",
                            UserName = "admin2@admin.com"
                        };

                        await userManager.CreateAsync(adminUser, "admin123");

                        await userManager.CreateAsync(adminUsertwo, "admin123");

                        await userManager.AddToRoleAsync(adminUser, roleName);
                    }
                }).Wait();


            }

            return app;
        }
    }
}
