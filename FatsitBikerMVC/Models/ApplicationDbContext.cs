using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FatsitBikerMVC.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<ProductImage> ProductImages { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductImage>()
                .HasOne(p => p.Product)
                .WithMany(b => b.ProductImages)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Xe tay ga" },
                new Category { Id = 2, Name = "Xe số" },
                new Category { Id = 3, Name = "Xe côn tay" },
                new Category { Id = 4, Name = "Xe điện" }
            );

            var products = new List<Product>();
            var productImages = new List<ProductImage>();
            int id = 1;
            int imgId = 1;

            string[] img1 = { "https://images.unsplash.com/photo-1558981403-c5f9899a28bc", "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f" };
            string[] img2 = { "https://images.unsplash.com/photo-1558980394-0a37b363a516", "https://images.unsplash.com/photo-1558981359-219d6364c9c8", "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e" };

            Random rnd = new Random(12345);
            Func<int, int, string> getPrice = (min, max) => (rnd.Next(min, max) * 1000000).ToString();

            void AddProductAndImages(int categoryId, string name, string price, string engine, string power, string weight)
            {
                products.Add(new Product { Id = id, CategoryId = categoryId, Name = name, Price = price, Desc = $"Mô tả chi tiết cho {name}", Engine = engine, Power = power, Weight = weight });
                productImages.Add(new ProductImage { Id = imgId++, ProductId = id, ImageUrl = img1[id % 3] });
                productImages.Add(new ProductImage { Id = imgId++, ProductId = id, ImageUrl = img2[id % 3] });
                id++;
            }

            string[] tayga = { "Honda SH 150i", "Honda Vision", "Honda Air Blade", "Honda Lead", "Honda Vario", "Yamaha NVX", "Yamaha Grande", "Yamaha Latte", "Yamaha FreeGo", "Vespa Sprint", "Vespa Primavera", "Piaggio Medley", "Piaggio Liberty" };
            foreach (var name in tayga) AddProductAndImages(1, name, getPrice(30, 100), "125cc", "10 HP", "110 kg");

            string[] xeso = { "Honda Wave Alpha", "Honda Wave RSX", "Honda Blade", "Honda Future", "Yamaha Sirius", "Yamaha Jupiter", "SYM Elegant", "SYM Galaxy", "Honda Super Cub", "Yamaha Finn", "SYM Angela", "SYM Star SR" };
            foreach (var name in xeso) AddProductAndImages(2, name, getPrice(15, 40), "110cc", "8 HP", "95 kg");

            string[] contay = { "Yamaha Exciter 155", "Honda Winner X", "Suzuki Raider", "Suzuki Satria", "Yamaha MT-15", "Honda CBR150R", "Yamaha R15", "Suzuki GSX-R150", "Honda MSX 125", "Kawasaki Z1000", "Ducati Panigale", "Yamaha MT-09" };
            foreach (var name in contay) AddProductAndImages(3, name, getPrice(45, 500), "150cc - 1000cc", "15 - 200 HP", "130 - 200 kg");

            string[] xedien = { "VinFast Feliz S", "VinFast Klara S", "VinFast Vento S", "VinFast Theon S", "VinFast Evo 200", "Yadea Odora", "Yadea Xmen", "Pega S", "Dat Bike Weaver", "Dat Bike Weaver 200", "Dat Bike Weaver++", "Yadea Ulike", "Dibao Gogo" };
            foreach (var name in xedien) AddProductAndImages(4, name, getPrice(15, 70), "Điện", "1000W - 3000W", "90 - 120 kg");

            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<ProductImage>().HasData(productImages);
        }
    }
}
