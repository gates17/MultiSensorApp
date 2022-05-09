using Microsoft.EntityFrameworkCore;
using MultiSensorAppApi.Models;

namespace MultiSensorAppApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }


        public DbSet<Alert> Alerts { get; set; }

        public DbSet<AlertConfiguration> AlertConfigurations { get; set; }

        public DbSet<AlertLevel> AlertLevels { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Sensor> Sensors { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
