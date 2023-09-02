using BlazorProject.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Server
{
    public class MedicineDbContext : DbContext
    {
        public MedicineDbContext(DbContextOptions<MedicineDbContext> options) : base(options) { }
        public DbSet<Patient> Patients { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderItem> OrderItems { get; set; } = default!;
        public DbSet<Medicine> Medicinets { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasKey(o => new { o.OrderID, o.MedicineID });
        }
    }
}
