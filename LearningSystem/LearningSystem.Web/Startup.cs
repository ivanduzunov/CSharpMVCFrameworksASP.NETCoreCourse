﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LearningSystem.Data;
using LearningSystem.Data.Models;
using LearningSystem.Web.Services;
using LearningSystem.Web.Infrastructure.Extentions;
using LearningSystem.Services.Admin;
using LearningSystem.Services.Admin.Implementations;
using Microsoft.AspNetCore.Mvc;
using LearningSystem.Services.Articles;
using LearningSystem.Services.Articles.Implementations;
using LearningSystem.Services.Course;
using LearningSystem.Services.Course.Implementations;
using LearningSystem.Services.User;
using LearningSystem.Services.User.Implementations;
using LearningSystem.Services.Trainer;
using LearningSystem.Services.Trainer.Implementations;

namespace LearningSystem.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LearningSystemDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<LearningSystemDbContext>()
                .AddDefaultTokenProviders();

            services.AddAutoMapper();

            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddTransient<IAdminUserService, AdminUserService>();

            services.AddTransient<IAdminCourseService, AdminCourseService>();

            services.AddTransient<IArticlesService, ArticlesService>();

            services.AddTransient<ICourseService, CourseService>();

            services.AddTransient<IUserSevice, UserService>();

            services.AddTransient<ITrainerService, TrainerService>();

            services.AddMvc(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });
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
                   name: "profile",
                   template: "users/{username}",
                   defaults: new {controller = "Users", action = "Profile"});

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
