using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BusinessObjects
{
    public class VegeFoodDBContext : DbContext
    {
        public VegeFoodDBContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("VegeFoodDB"));
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Root" },
                new Category { CategoryId = 2, CategoryName = "Fruit" },
                new Category { CategoryId = 3, CategoryName = "Leafy Greens" },
                new Category { CategoryId = 4, CategoryName = "Mushrooms" },
                new Category { CategoryId = 5, CategoryName = "Herbs" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    ProductName = "Carrot",
                    CategoryId = 1,
                    UnitPrice = 5000,
                    UnitInStock = 1000,
                    ProductImage = "https://5.imimg.com/data5/SELLER/Default/2023/3/WB/RV/ZG/137288736/12818-1-500x500.webp",
                    Description = "This is carrot"
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Apple",
                    CategoryId = 2,
                    UnitPrice = 3000,
                    UnitInStock = 800,
                    ProductImage = "https://media.istockphoto.com/id/184276818/photo/red-apple.jpg?s=612x612&w=0&k=20&c=NvO-bLsG0DJ_7Ii8SSVoKLurzjmV0Qi4eGfn6nW3l5w=",
                    Description = "Fresh apples"
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Banana",
                    CategoryId = 2,
                    UnitPrice = 2500,
                    UnitInStock = 1200,
                    ProductImage = "https://fruitboxco.com/cdn/shop/products/asset_2_1024x.jpg?v=1571839043",
                    Description = "Ripe bananas"
                },
                new Product
                {
                    ProductId = 4,
                    ProductName = "Orange",
                    CategoryId = 1,
                    UnitPrice = 3500,
                    UnitInStock = 600,
                    ProductImage = "https://d2b5e9fzla1xs8.cloudfront.net/media/images/products/2021/03/3007.jpg",
                    Description = "Juicy oranges"
                },
                new Product
                {
                    ProductId = 5,
                    ProductName = "Grapes",
                    CategoryId = 2,
                    UnitPrice = 4500,
                    UnitInStock = 500,
                    ProductImage = "https://media.istockphoto.com/id/1158975684/photo/grapes-red-grape-grape-branch-isolated-on-white.jpg?s=612x612&w=0&k=20&c=9A8zhyTwckgPjTbIZUm_9DDJEWKJqBp1p2f0YqZ2FQA=",
                    Description = "Sweet grapes"
                },
                new Product
                {
                    ProductId = 6,
                    ProductName = "Watermelon",
                    CategoryId = 2,
                    UnitPrice = 6000,
                    UnitInStock = 300,
                    ProductImage = "https://natureandnurtureseeds.com/cdn/shop/products/046_final_cropped_for_website.jpg?v=1579884015",
                    Description = "Fresh watermelon"
                },
                new Product
                {
                    ProductId = 7,
                    ProductName = "Strawberry",
                    CategoryId = 2,
                    UnitPrice = 5500,
                    UnitInStock = 700,
                    ProductImage = "https://cdn.britannica.com/20/174520-050-64C6FD6B/Cartons-strawberries-farmers-market.jpg",
                    Description = "Delicious strawberries"
                },
                new Product
                {
                    ProductId = 8,
                    ProductName = "Pineapple",
                    CategoryId = 2,
                    UnitPrice = 4800,
                    UnitInStock = 400,
                    ProductImage = "https://www.allrecipes.com/thmb/SbBpjqfquAd7LkvL7O3MbeccniA=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/GettyImages-1178065904-2000-6f4d99c79ab94b0e85d2a64794a09adc.jpg",
                    Description = "Tropical pineapple"
                },
                new Product
                {
                    ProductId = 9,
                    ProductName = "Mango",
                    CategoryId = 2,
                    UnitPrice = 5200,
                    UnitInStock = 600,
                    ProductImage = "https://post.medicalnewstoday.com/wp-content/uploads/sites/3/2022/01/mangoes_what_to_know_732x549_thumb-732x549.jpg",
                    Description = "Exotic mangoes"
                },
                new Product
                {
                    ProductId = 10,
                    ProductName = "Lemon",
                    CategoryId = 2,
                    UnitPrice = 2800,
                    UnitInStock = 900,
                    ProductImage = "https://www.tastingtable.com/img/gallery/31-types-of-lemons-and-what-makes-them-unique/l-intro-1656086555.jpg",
                    Description = "Fresh lemons"
                },
                 new Product
                 {
                     ProductId = 11,
                     ProductName = "Spinach",
                     CategoryId = 3,
                     UnitPrice = 5100,
                     UnitInStock = 1000,
                     ProductImage = "https://freshji.in/wp-content/uploads/2020/09/Spinach-1.jpg",
                     Description = "Fresh Spinach"
                 },
                new Product
                {
                    ProductId = 12,
                    ProductName = "Watercress",
                    CategoryId = 3,
                    UnitPrice = 6300,
                    UnitInStock = 1000,
                    ProductImage = "https://www.kitchengardenseeds.com/media/catalog/product/cache/0e0f8b55cb1429f46d7faa85732ae262/w/a/watercress-w.jpg",
                    Description = "Fresh Watercress"
                },
                new Product
                {
                    ProductId = 13,
                    ProductName = "Romaine",
                    CategoryId = 3,
                    UnitPrice = 4500,
                    UnitInStock = 1000,
                    ProductImage = "https://cdn-prod.medicalnewstoday.com/content/images/articles/319/319725/romaine-lettuce-on-wooden-chopping-board.jpg",
                    Description = "Fresh Romaine"
                },
                new Product
                {
                    ProductId = 14,
                    ProductName = "Mustard Greens",
                    CategoryId = 3,
                    UnitPrice = 7000,
                    UnitInStock = 1000,
                    ProductImage = "https://www.highmowingseeds.com/media/catalog/product/cache/6cbdb003cf4aae33b9be8e6a6cf3d7ad/2/4/2485-1.jpg",
                    Description = "Fresh Greens"
                },
                new Product
                {
                    ProductId = 15,
                    ProductName = "Bok Choy",
                    CategoryId = 3,
                    UnitPrice = 3000,
                    UnitInStock = 1000,
                    ProductImage = "https://www.veggycation.com.au/siteassets/veggycationvegetable/bok-choy.jpg",
                    Description = "Fresh Bok Choy"
                },
                new Product
                {
                    ProductId = 16,
                    ProductName = "Swiss Chard",
                    CategoryId = 3,
                    UnitPrice = 7000,
                    UnitInStock = 1000,
                    ProductImage = "https://5.imimg.com/data5/SELLER/Default/2023/3/WB/RV/ZG/137288736/12818-1-500x500.webp",
                    Description = "Fresh Swiss Chard"
                },
                new Product
                {
                    ProductId = 17,
                    ProductName = "Collard Greens",
                    CategoryId = 3,
                    UnitPrice = 6000,
                    UnitInStock = 1000,
                    ProductImage = "https://mountaingirl.camp/wp-content/uploads/2020/08/how-to-cook-collard-greens.png",
                    Description = "Fresh Collard Greens"
                },
                new Product
                {
                    ProductId = 18,
                    ProductName = "Arugula",
                    CategoryId = 3,
                    UnitPrice = 6600,
                    UnitInStock = 1000,
                    ProductImage = "https://www.highmowingseeds.com/media/catalog/product/cache/6cbdb003cf4aae33b9be8e6a6cf3d7ad/2/0/2005-1.jpg",
                    Description = "Fresh Arugula"
                },
                new Product
                {
                    ProductId = 19,
                    ProductName = "Lettuce",
                    CategoryId = 3,
                    UnitPrice = 7700,
                    UnitInStock = 1000,
                    ProductImage = "https://zipgrow.com/wp-content/uploads/2022/05/Lettuce-Head-scaled-1.jpeg",
                    Description = "Fresh Lettuce"
                },
                new Product
                {
                    ProductId = 20,
                    ProductName = "Kale",
                    CategoryId = 3,
                    UnitPrice = 8800,
                    UnitInStock = 1000,
                    ProductImage = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Boerenkool.jpg/1200px-Boerenkool.jpg",
                    Description = "Fresh Kale"
                },
                new Product
                {
                    ProductId = 21,
                    ProductName = "Button Mushroom",
                    CategoryId = 4,
                    UnitPrice = 8800,
                    UnitInStock = 1000,
                    ProductImage = "https://www.thespruceeats.com/thmb/PDnFtFMkfMsRBC1XqhCv0OP-J6I=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/what-are-button-mushrooms-5197530-hero-06-3d46a10b9e924f67849d5e7a049a6a2d.jpg",
                    Description = "Fresh Button Mushroom"
                },
                new Product
                {
                    ProductId = 22,
                    ProductName = "Shiitake Mushroom",
                    CategoryId = 4,
                    UnitPrice = 8800,
                    UnitInStock = 1000,
                    ProductImage = "https://cdn.britannica.com/47/182647-050-EA329FC3/shiitake-mushrooms.jpg",
                    Description = "Fresh Shiitake Mushroom"
                },
                new Product
                {
                    ProductId = 23,
                    ProductName = "Portobello Mushroom",
                    CategoryId = 4,
                    UnitPrice = 8800,
                    UnitInStock = 1000,
                    ProductImage = "https://upload.wikimedia.org/wikipedia/commons/3/3e/Portobello_mushrooms.jpg",
                    Description = "Fresh Portobello Mushroom"
                },
                new Product
                {
                    ProductId = 24,
                    ProductName = "Morel Mushroom",
                    CategoryId = 4,
                    UnitPrice = 8800,
                    UnitInStock = 1000,
                    ProductImage = "https://static01.nyt.com/images/2022/04/11/science/00SCI-MORELS3/merlin_205361283_e07e1753-e0bd-4eff-8c45-35442cb8c8d1-mediumSquareAt3X.jpg",
                    Description = "Fresh Morel Mushroom"
                },
                new Product
                {
                    ProductId = 25,
                    ProductName = "Chanterelle Mushroom",
                    CategoryId = 4,
                    UnitPrice = 8800,
                    UnitInStock = 1000,
                    ProductImage = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9a/Chanterelle_Cantharellus_cibarius.jpg/1023px-Chanterelle_Cantharellus_cibarius.jpg",
                    Description = "Fresh Chanterelle Mushroom"
                },
                new Product
                {
                    ProductId = 26,
                    ProductName = "Basil",
                    CategoryId = 5,
                    UnitPrice = 8800,
                    UnitInStock = 1000,
                    ProductImage = "https://images.pexels.com/photos/1087902/pexels-photo-1087902.jpeg?cs=srgb&dl=pexels-monicore-1087902.jpg&fm=jpg",
                    Description = "Fresh basil"
                },
                new Product
                {
                    ProductId = 27,
                    ProductName = "Parsley",
                    CategoryId = 5,
                    UnitPrice = 8800,
                    UnitInStock = 1000,
                    ProductImage = "https://cdn.britannica.com/63/193863-050-0EC30803/Parsley.jpg",
                    Description = "Fresh Parsley"
                },
                new Product
                {
                    ProductId = 28,
                    ProductName = "Cilantro",
                    CategoryId = 5,
                    UnitPrice = 8800,
                    UnitInStock = 1000,
                    ProductImage = "https://images.cookforyourlife.org/wp-content/uploads/2018/08/shutterstock_224264125-min.jpg",
                    Description = "Fresh Cilantro"
                },
                new Product
                {
                    ProductId = 29,
                    ProductName = "Rosemary",
                    CategoryId = 5,
                    UnitPrice = 8800,
                    UnitInStock = 1000,
                    ProductImage = "https://m.media-amazon.com/images/I/61L6xhYXiuL._AC_UF1000,1000_QL80_.jpg",
                    Description = "Fresh Rosemary"
                },
                new Product
                {
                    ProductId = 30,
                    ProductName = "Mint",
                    CategoryId = 5,
                    UnitPrice = 8800,
                    UnitInStock = 1000,
                    ProductImage = "https://assets.epicurious.com/photos/5763132cff66dde1456dfed0/4:3/w_1768,h_1326,c_limit/Mint_Leaves.jpg",
                    Description = "Fresh Mint"
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User {AccountId = 1, UserName ="admin", Password="123456", Address="Hanoi", Email="admin@gmail.com", FullName="Admin Nguyen", Phone="0969999999", role="Admin" },
                new User { AccountId = 2, UserName = "kien", Password = "1234", Address = "Hanoi", Email = "kien@gmail.com", FullName = "Kien Tran", Phone = "0838776396", role = "Customer" },
                new User { AccountId = 3, UserName = "tung", Password = "5678", Address = "Hanoi", Email = "tung@gmail.com", FullName = "Tung Hoang", Phone = "0838776369", role = "Customer" }
            );
        }
    }
}