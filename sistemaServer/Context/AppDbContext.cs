using Microsoft.EntityFrameworkCore;
using sistemaServer.Context.Map;
using sistemaServer.Models;

namespace sistemaServer.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<RentModel> Rents { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<SupplierModel> Suppliers { get; set; }
        public DbSet<PartnerModel> Partners { get; set; }
        public DbSet<LocationModel> Locations { get; set; }
        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<StateModel> States { get; set; }
        public DbSet<CityModel> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.ApplyConfiguration(new RentMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());

            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new SupplierMap());
            modelBuilder.ApplyConfiguration(new PartnerMap());

            modelBuilder.ApplyConfiguration(new LocationMap());
            modelBuilder.ApplyConfiguration(new CountryMap());
            modelBuilder.ApplyConfiguration(new StateMap());
            modelBuilder.ApplyConfiguration(new CityMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
