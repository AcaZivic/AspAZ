
using AspAZ.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.DataAccess
{
    public class GameKingdomContext : DbContext
    {
        private readonly string _connectionString;

        //public GameKingdomContext(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        public GameKingdomContext()
        {
            _connectionString = @"Data Source=DESKTOP-ACAZ\SQLEXPRESS;Initial Catalog=AspProjectGK;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            var manufacturers = new List<Manufacturer> { 
                new Manufacturer{
                    Id = 1,
                    Name = "Asus"
                },
                new Manufacturer
                {
                    Id=2,
                    Name="Redragon"
                }
            };

            modelBuilder.Entity<Manufacturer>().HasData(manufacturers);
            
            modelBuilder.Entity<PriceList>().HasOne(x => x.Product)
                                          .WithOne(x => x.PriceList)
                                          .HasForeignKey<Product>(x => x.PriceListId)
                                          .OnDelete(DeleteBehavior.Restrict)
                                          .IsRequired();

            modelBuilder.Entity<PropertyCategory>().HasKey(x => new { x.PropertyId,x.CategoryId});
            modelBuilder.Entity<ProductProperty>().HasKey(keyExpression: x => new { x.ProductId, x.PropertyId });
            modelBuilder.Entity<ShopStorage>().HasKey(x => new { x.ProductId, x.RetailShopId });
            modelBuilder.Entity<ProductCart>().HasKey(x => new { x.ProductId, x.CartId });


            modelBuilder.Entity<Manufacturer>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<GroupEmp>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Customer>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Employee>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Property>().HasQueryFilter(x => !x.IsDeleted);
            //modelBuilder.Entity<PriceList>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(x => !x.IsDeleted);
        }

        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entries = this.ChangeTracker.Entries();

            foreach (EntityEntry entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.isActive = true;
                        e.CreatedAt = DateTime.UtcNow;
                    }
                }

                if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.ModifiedAt = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChanges();
        }

        

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Property> Properties{ get; set; }
        public DbSet<RetailShop> RetailShops { get; set; }
        public DbSet<GroupEmp> GroupEmps { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }

    }
}
