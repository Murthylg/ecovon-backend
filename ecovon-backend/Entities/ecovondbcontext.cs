using ecovon_backend.Entities.Vendors;
using Microsoft.EntityFrameworkCore;
using ecovon_backend.Models.Vendors;

namespace ecovon_backend.Entities
{
    public class ecovondbcontext : DbContext
    {
        public ecovondbcontext(DbContextOptions options): base(options)
        {            
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<ServiceRequest> ServiceRequest { get; set; }
        public DbSet<ServiceType> ServiceType { get; set; }
        public DbSet<ServiceRequestDetail> serviceRequestDetail { get; set; }
        public DbSet<ServiceCategory> ServiceCategory { get; set; }
        public DbSet<VendorTypeOfWork> VendorTypeOfWork { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<ecovon_backend.Models.Vendors.VendorModel> VendorModel { get; set; }
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Customer>().ToTable("Customer");
    //}
}
