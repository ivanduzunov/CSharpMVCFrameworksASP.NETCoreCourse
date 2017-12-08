namespace UndergroundStation.Web
{
    using AutoMapper;
    using Data;
    using Data.Models;
    using Infrastructure.Extentions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using UndergroundStation.Services;
    using UndergroundStation.Services.Implementations;
    using UndergroundStation.Services.Admin;
    using UndergroundStation.Services.Admin.Implementations;
    using UndergroundStation.Services.Author;
    using UndergroundStation.Services.Author.Implementations;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UndergroundStationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })

                .AddEntityFrameworkStores<UndergroundStationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAutoMapper();

            services.AddTransient<INewsService, NewsService>();

            services.AddTransient<IAdminUserService, AdminUserService>();

            services.AddTransient<IAuthorArticleService, AuthorArticleService>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDatabaseMigration();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "areas",
                   template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
