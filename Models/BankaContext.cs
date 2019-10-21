using Microsoft.EntityFrameworkCore;

namespace Banka.Models
{
    public class BankaContext : DbContext
    {
        public BankaContext(DbContextOptions<BankaContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}