using ContactService.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Example DbSet
        public DbSet<Contact> Contacts { get; set; }
    }
}