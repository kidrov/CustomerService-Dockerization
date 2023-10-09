using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class KeepDbContext:DbContext
    {
        public KeepDbContext() { }
        public KeepDbContext(DbContextOptions<KeepDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
