using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LearningSystem.Data.Models;

namespace LearningSystem.Data
{
    public class LearningSystemDbContext : IdentityDbContext<User>
    {
        public LearningSystemDbContext(DbContextOptions<LearningSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder.Entity<Course>()
                .HasMany(sc => sc.Students)
                .WithOne(c => c.Course)
                .HasForeignKey(sc => sc.CourseId);

            builder.Entity<User>()
               .HasMany(sc => sc.Courses)
               .WithOne(c => c.Student)
               .HasForeignKey(sc => sc.StudentId);

            builder.Entity<User>()
                .HasMany(u => u.Trainings)
                .WithOne(c => c.Trainer)
                .HasForeignKey(c => c.TrainerId);

            builder.Entity<Article>()
                .HasOne(a => a.Author)
                .WithMany(u => u.Articles)
                .HasForeignKey(a => a.AuthorId);

            base.OnModelCreating(builder);
        }
    }
}
