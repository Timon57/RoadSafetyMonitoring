using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoadSafety.Models.Domain;

namespace RoadSafety.Data
{
    public class RoadDbContext:IdentityDbContext
    {
        public RoadDbContext(DbContextOptions<RoadDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Feedback> feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var trafficRoleId = "1";
            var userRoleId = "2";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = trafficRoleId,
                    ConcurrencyStamp = trafficRoleId,
                    Name = "Traffic",
                    NormalizedName = "traffic".ToUpper()
                },
                new IdentityRole
                {
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = "User",
                    NormalizedName = "user".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
