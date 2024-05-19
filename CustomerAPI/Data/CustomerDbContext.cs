using CustomersUI.Model;
using Microsoft.EntityFrameworkCore;
using static CustomersUI.Model.Customer;
using static CustomersUI.Model.Customer.Travel;

namespace CustomerAPI.Data
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Customer.Company> Companies { get; set; }
        public DbSet<Customer.Card> Cards { get; set; }
        public DbSet<Customer.Travel> Travels { get; set; }
        public DbSet<Customer.Travel.Passenger> Passengers { get; set; }
        public DbSet<Customer.Travel.Transfer> Transfers { get; set; }
        public DbSet<Customer.Action> Actions { get; set; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasMany(c => c.Cards).WithOne().HasForeignKey(c => c.CustomerId);
            modelBuilder.Entity<Customer>().HasMany(c => c.Travels).WithOne().HasForeignKey(t => t.CustomerId);
            modelBuilder.Entity<Customer>().HasMany(c => c.Actions).WithOne().HasForeignKey(a => a.CustomerId);
            modelBuilder.Entity<Customer.Travel>().HasMany(t => t.Passengers).WithOne().HasForeignKey(p => p.TravelId);
            modelBuilder.Entity<Customer.Travel>().HasMany(t => t.Transfers).WithOne().HasForeignKey(tr => tr.TravelId);
        }
    }
}
