using Microsoft.EntityFrameworkCore;

namespace Ira.Repositories.Context
{
    public class IraContext: DbContext
    {
        public IraContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
