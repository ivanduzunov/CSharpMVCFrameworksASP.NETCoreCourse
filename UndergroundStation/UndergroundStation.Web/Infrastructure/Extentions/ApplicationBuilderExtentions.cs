namespace UndergroundStation.Web.Infrastructure.Extentions
{
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;

    public static class ApplicationBuilderExtentions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<UndergroundStationDbContext>()
                .Database.Migrate();

                //    var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                //    var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                //    Task.Run(async () =>
                //    {
                //        var adminRole = WebConstants.AdministratorRole;

                //        var roles = new[]
                //        {
                //            adminRole,
                //            AuthorRole,
                //            PublisherRole
                //        };

                //        foreach (var role in roles)
                //        {
                //            var roleExists = await roleManager.RoleExistsAsync(role);

                //            if (!roleExists)
                //            {
                //                var result = await roleManager.CreateAsync(new IdentityRole
                //                {
                //                    Name = role
                //                });
                //            }
                //        }
                //        var adminEmail = "admin@admin.com";

                //        var adminUser = await userManager.FindByEmailAsync(adminEmail);

                //        if (adminUser == null)
                //        {
                //            adminUser = new User
                //            {
                //                Email = adminEmail,
                //                UserName = adminRole,
                //                Name = adminRole,
                //                Birthdate = DateTime.UtcNow
                //            };

                //            await userManager.CreateAsync(adminUser, "admin1234");

                //            await userManager.AddToRoleAsync(adminUser, adminRole);
                //        }
                //    }).Wait();
            }
            return app;
        }
    }
}
