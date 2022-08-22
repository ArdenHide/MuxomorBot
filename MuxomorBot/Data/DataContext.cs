using Microsoft.EntityFrameworkCore;
using MuxomorBot.Data.Entities;
using MuxomorBot.Keyboards;
using System.Collections.Generic;

namespace MuxomorBot.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MuxomorBot;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Category> Categories = new()
            {
                new Category { Name = "WholeCaps", DisplayName = Emoji.Mushroom + "Целые шляпки мухомора" },
                new Category { Name = "Crushed", DisplayName = Emoji.Mushroom + "Молотый мухомор" },
                new Category { Name = "Pills", DisplayName = Emoji.Pill + "Капсулы мухомора" },
                new Category { Name = "Chocolate", DisplayName = Emoji.Chocolate + "Мухоморный шоколад" },
                new Category { Name = "Infusion", DisplayName = Emoji.Oil + "Настойка мухомора" },
                new Category { Name = "Oil", DisplayName = Emoji.Oil + "Масла с мухомором" }
            };
            modelBuilder.Entity<Category>().HasData(Categories);

            string OpenedDescription = "Сушеные целые и частично ломаные шляпки мухомора красного Amanita Muscaria. Практически без песка.";
            string UnopenedDescription = "Сухие нераскрытые шляпки красного мухомора Amanita Muscaria.";
            string PantherDescription = "Целые и частично ломаные шляпки Amanita Pantherina. Почти без песка.";
            string VipDescription = "Целые и частично ломаные шляпки Amanita Pantherina. Почти без песка.";
            Category WholeCapsCategory = Categories[0];
            List<Product> WholeCaps = new()
            {
                /* Раскрытые шляпки мухомора Amanita Muscaria */
                new Product {
                    Name = "Раскрытые шляпки 50 гр",
                    Type = "Opened",
                    Weight = 50,
                    Price = 300,
                    Photo = "src/img/WholeCaps/Opened/50.png",
                    IsAvailability = true,
                    Description = OpenedDescription,
                    Category = WholeCapsCategory
                },
                new Product {
                    Name = "Раскрытые шляпки 100 гр",
                    Type = "Opened",
                    Weight = 100,
                    Price = 600,
                    Photo = "src/img/WholeCaps/Opened/100.png",
                    IsAvailability = true,
                    Description = OpenedDescription,
                    Category = WholeCapsCategory
                },
                new Product {
                    Name = "Раскрытые шляпки 200 гр",
                    Type = "Opened",
                    Weight = 200,
                    Price = 1100,
                    Photo = "src/img/WholeCaps/Opened/200.png",
                    IsAvailability = true,
                    Description = OpenedDescription,
                    Category = WholeCapsCategory
                },
                new Product {
                    Name = "Раскрытые шляпки 500 гр",
                    Type = "Opened",
                    Weight = 500,
                    Price = 3000,
                    Photo = "src/img/WholeCaps/Opened/500.png",
                    IsAvailability = true,
                    Description = OpenedDescription,
                    Category = WholeCapsCategory
                },
                /* Не раскрытые шляпки мухомора Amanita Muscaria */
                new Product {
                    Name = "Не раскрытые шляпки 50 гр",
                    Type = "Unopened",
                    Weight = 50,
                    Price = 300,
                    Photo = "src/img/WholeCaps/Unopened/50.png",
                    IsAvailability = true,
                    Description = UnopenedDescription,
                    Category = WholeCapsCategory
                },
                new Product {
                    Name = "Не раскрытые шляпки 100 гр",
                    Type = "Unopened",
                    Weight = 100,
                    Price = 600,
                    Photo = "src/img/WholeCaps/Unopened/100.png",
                    IsAvailability = true,
                    Description = UnopenedDescription,
                    Category = WholeCapsCategory
                },
                /* Шляпки Amanita Pantherina */
                new Product {
                    Name = "Не раскрытые шляпки 25 гр",
                    Type = "Panther",
                    Weight = 25,
                    Price = 500,
                    Photo = "src/img/WholeCaps/Panther/25.png",
                    IsAvailability = false,
                    Description = PantherDescription,
                    Category = WholeCapsCategory
                },
                new Product {
                    Name = "Не раскрытые шляпки 50 гр",
                    Type = "Panther",
                    Weight = 50,
                    Price = 990,
                    Photo = "src/img/WholeCaps/Panther/50.png",
                    IsAvailability = false,
                    Description = PantherDescription,
                    Category = WholeCapsCategory
                },
                /* Vip шляпки мухомора */
                new Product {
                    Name = "VIP шляпки, в подарочной упаковке 50 гр",
                    Type = "Vip",
                    Weight = 50,
                    Price = 300,
                    Photo = "src/img/WholeCaps/Vip/50.png",
                    IsAvailability = true,
                    Description = VipDescription,
                    Category = WholeCapsCategory
                },
                new Product {
                    Name = "VIP шляпки, в подарочной упаковке 100 гр",
                    Type = "Vip",
                    Weight = 100,
                    Price = 600,
                    Photo = "src/img/WholeCaps/Vip/100.png",
                    IsAvailability = true,
                    Description = VipDescription,
                    Category = WholeCapsCategory
                },
            };

            modelBuilder.Entity<Product>().HasData(WholeCaps);
        }
    }
}
