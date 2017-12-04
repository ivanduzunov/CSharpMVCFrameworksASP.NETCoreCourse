namespace UndergroundStation.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class UndergroundStationDbContext : IdentityDbContext<User>
    {
        public UndergroundStationDbContext(DbContextOptions<UndergroundStationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
