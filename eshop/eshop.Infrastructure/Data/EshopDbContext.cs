using eshop.Entities;
using Microsoft.EntityFrameworkCore;

namespace eshop.Infrastructure.Data
{
    public class EshopDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public EshopDbContext(DbContextOptions<EshopDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired()
                                                                .HasMaxLength(200);

            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);


            List<Category> categories = new()
            {
                new(){ Id=1, Name="Elektronik"},
                new(){ Id=2, Name="Kırtasiye"},
                new(){ Id=3, Name="Müzik"},

            };

            modelBuilder.Entity<Category>().HasData(categories);

            List<Product> products = new()
            {
                new(){ Id=1, CategoryId=1, Description="Laptop Dell XPS 13", Discount=0.20M, Name="Dell XPS", Price=65000, StockCount=100},
                new(){ Id=2, CategoryId=2, Description="Beyaz Tahta", Discount=0.20M, Name="BT 1000", Price=570, StockCount=100},
                new(){ Id=3, CategoryId=3, Description="Yamaha Drum Set", Discount=0.20M, Name="Drum set...", Price=65000, StockCount=100},
                new(){ Id=4, CategoryId=1, Description="Mac Book Pro ", Discount=0.20M, Name="M2", Price=120000, StockCount=100},

            };

            modelBuilder.Entity<Product>().HasData(products);


        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer();

        //}
    }
}
