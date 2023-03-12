using Ira.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ira.Repositories.Context
{
    public class IraContext: DbContext
    {
        public DbSet<Crew> Crew { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Label> Label { get; set; }
        public DbSet<Mission> Mission { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<Ship> Ship { get; set; }

        public IraContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
