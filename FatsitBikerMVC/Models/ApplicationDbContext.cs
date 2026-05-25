using Microsoft.EntityFrameworkCore;

namespace FatsitBikerMVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Xe tay ga" },
                new Category { Id = 2, Name = "Xe số" },
                new Category { Id = 3, Name = "Xe côn tay" },
                new Category { Id = 4, Name = "Xe điện" }
            );

            var products = new List<Product>();
            int id = 1;

            string[] img1 = { "https://images.unsplash.com/photo-1558981403-c5f9899a28bc", "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f" };
            string[] img2 = { "https://images.unsplash.com/photo-1558980394-0a37b363a516", "https://images.unsplash.com/photo-1558981359-219d6364c9c8", "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e" };

            Random rnd = new Random(12345);
            Func<int, int, string> getPrice = (min, max) => (rnd.Next(min, max) * 1000000).ToString();

            string[] tayga = { "Honda SH 150i", "Honda Vision", "Honda Air Blade", "Honda Lead", "Honda Vario", "Yamaha NVX", "Yamaha Grande", "Yamaha Latte", "Yamaha FreeGo", "Vespa Sprint", "Vespa Primavera", "Piaggio Medley", "Piaggio Liberty" };
            foreach (var name in tayga) {
                products.Add(new Product { Id = id++, CategoryId = 1, Name = name, Price = getPrice(30, 100), Images = new List<string> { img1[id%3], img2[id%3] }, Desc = $"Mô tả chi tiết cho {name}", Engine = "125cc", Power = "10 HP", Weight = "110 kg" });
            }

            string[] xeso = { "Honda Wave Alpha", "Honda Wave RSX", "Honda Blade", "Honda Future", "Yamaha Sirius", "Yamaha Jupiter", "SYM Elegant", "SYM Galaxy", "Honda Super Cub", "Yamaha Finn", "SYM Angela", "SYM Star SR" };
            foreach (var name in xeso) {
                products.Add(new Product { Id = id++, CategoryId = 2, Name = name, Price = getPrice(15, 40), Images = new List<string> { img1[id%3], img2[id%3] }, Desc = $"Mô tả chi tiết cho {name}", Engine = "110cc", Power = "8 HP", Weight = "95 kg" });
            }

            string[] contay = { "Yamaha Exciter 155", "Honda Winner X", "Suzuki Raider", "Suzuki Satria", "Yamaha MT-15", "Honda CBR150R", "Yamaha R15", "Suzuki GSX-R150", "Honda MSX 125", "Kawasaki Z1000", "Ducati Panigale", "Yamaha MT-09" };
            foreach (var name in contay) {
                products.Add(new Product { Id = id++, CategoryId = 3, Name = name, Price = getPrice(45, 500), Images = new List<string> { img1[id%3], img2[id%3] }, Desc = $"Mô tả chi tiết cho {name}", Engine = "150cc - 1000cc", Power = "15 - 200 HP", Weight = "130 - 200 kg" });
            }

            string[] xedien = { "VinFast Feliz S", "VinFast Klara S", "VinFast Vento S", "VinFast Theon S", "VinFast Evo 200", "Yadea Odora", "Yadea Xmen", "Pega S", "Dat Bike Weaver", "Dat Bike Weaver 200", "Dat Bike Weaver++", "Yadea Ulike", "Dibao Gogo" };
            foreach (var name in xedien) {
                products.Add(new Product { Id = id++, CategoryId = 4, Name = name, Price = getPrice(15, 70), Images = new List<string> { img1[id%3], img2[id%3] }, Desc = $"Mô tả chi tiết cho {name}", Engine = "Điện", Power = "1000W - 3000W", Weight = "90 - 120 kg" });
            }

            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
