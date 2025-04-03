using JMSmedical.Models;
using Microsoft.EntityFrameworkCore;
namespace JMSmedical.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
