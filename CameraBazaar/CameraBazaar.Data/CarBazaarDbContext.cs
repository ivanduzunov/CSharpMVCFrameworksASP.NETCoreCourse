using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CameraBazaar.Data.Models;

namespace CameraBazaar.Data
{
    public class CarBazaarDbContext : IdentityDbContext<User>
    {
        public CarBazaarDbContext(DbContextOptions<CarBazaarDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);          
        }
    }
}
