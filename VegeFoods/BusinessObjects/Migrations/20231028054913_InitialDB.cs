using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UnitInStock = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    UserAccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "Users",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Root" },
                    { 2, "Fruit" },
                    { 3, "Leafy Greens" },
                    { 4, "Mushrooms" },
                    { 5, "Herbs" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AccountId", "Address", "Email", "FullName", "Password", "Phone", "UserName", "role" },
                values: new object[,]
                {
                    { 1, "Hanoi", "admin@gmail.com", "Admin Nguyen", "123456", "0969999999", "admin", "Admin" },
                    { 2, "Hanoi", "kien@gmail.com", "Kien Tran", "1234", "0838776396", "kien", "Customer" },
                    { 3, "Hanoi", "tung@gmail.com", "Tung Hoang", "5678", "0838776369", "tung", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ProductImage", "ProductName", "UnitInStock", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, "This is carrot", "https://5.imimg.com/data5/SELLER/Default/2023/3/WB/RV/ZG/137288736/12818-1-500x500.webp", "Carrot", 1000, 5000m },
                    { 2, 2, "Fresh apples", "https://media.istockphoto.com/id/184276818/photo/red-apple.jpg?s=612x612&w=0&k=20&c=NvO-bLsG0DJ_7Ii8SSVoKLurzjmV0Qi4eGfn6nW3l5w=", "Apple", 800, 3000m },
                    { 3, 2, "Ripe bananas", "https://fruitboxco.com/cdn/shop/products/asset_2_1024x.jpg?v=1571839043", "Banana", 1200, 2500m },
                    { 4, 1, "Juicy oranges", "https://d2b5e9fzla1xs8.cloudfront.net/media/images/products/2021/03/3007.jpg", "Orange", 600, 3500m },
                    { 5, 2, "Sweet grapes", "https://media.istockphoto.com/id/1158975684/photo/grapes-red-grape-grape-branch-isolated-on-white.jpg?s=612x612&w=0&k=20&c=9A8zhyTwckgPjTbIZUm_9DDJEWKJqBp1p2f0YqZ2FQA=", "Grapes", 500, 4500m },
                    { 6, 2, "Fresh watermelon", "https://natureandnurtureseeds.com/cdn/shop/products/046_final_cropped_for_website.jpg?v=1579884015", "Watermelon", 300, 6000m },
                    { 7, 2, "Delicious strawberries", "https://cdn.britannica.com/20/174520-050-64C6FD6B/Cartons-strawberries-farmers-market.jpg", "Strawberry", 700, 5500m },
                    { 8, 2, "Tropical pineapple", "https://www.allrecipes.com/thmb/SbBpjqfquAd7LkvL7O3MbeccniA=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/GettyImages-1178065904-2000-6f4d99c79ab94b0e85d2a64794a09adc.jpg", "Pineapple", 400, 4800m },
                    { 9, 2, "Exotic mangoes", "https://post.medicalnewstoday.com/wp-content/uploads/sites/3/2022/01/mangoes_what_to_know_732x549_thumb-732x549.jpg", "Mango", 600, 5200m },
                    { 10, 2, "Fresh lemons", "https://www.tastingtable.com/img/gallery/31-types-of-lemons-and-what-makes-them-unique/l-intro-1656086555.jpg", "Lemon", 900, 2800m },
                    { 11, 3, "Fresh Spinach", "https://freshji.in/wp-content/uploads/2020/09/Spinach-1.jpg", "Spinach", 1000, 5100m },
                    { 12, 3, "Fresh Watercress", "https://www.kitchengardenseeds.com/media/catalog/product/cache/0e0f8b55cb1429f46d7faa85732ae262/w/a/watercress-w.jpg", "Watercress", 1000, 6300m },
                    { 13, 3, "Fresh Romaine", "https://cdn-prod.medicalnewstoday.com/content/images/articles/319/319725/romaine-lettuce-on-wooden-chopping-board.jpg", "Romaine", 1000, 4500m },
                    { 14, 3, "Fresh Greens", "https://www.highmowingseeds.com/media/catalog/product/cache/6cbdb003cf4aae33b9be8e6a6cf3d7ad/2/4/2485-1.jpg", "Mustard Greens", 1000, 7000m },
                    { 15, 3, "Fresh Bok Choy", "https://www.veggycation.com.au/siteassets/veggycationvegetable/bok-choy.jpg", "Bok Choy", 1000, 3000m },
                    { 16, 3, "Fresh Swiss Chard", "https://5.imimg.com/data5/SELLER/Default/2023/3/WB/RV/ZG/137288736/12818-1-500x500.webp", "Swiss Chard", 1000, 7000m },
                    { 17, 3, "Fresh Collard Greens", "https://mountaingirl.camp/wp-content/uploads/2020/08/how-to-cook-collard-greens.png", "Collard Greens", 1000, 6000m },
                    { 18, 3, "Fresh Arugula", "https://www.highmowingseeds.com/media/catalog/product/cache/6cbdb003cf4aae33b9be8e6a6cf3d7ad/2/0/2005-1.jpg", "Arugula", 1000, 6600m },
                    { 19, 3, "Fresh Lettuce", "https://zipgrow.com/wp-content/uploads/2022/05/Lettuce-Head-scaled-1.jpeg", "Lettuce", 1000, 7700m },
                    { 20, 3, "Fresh Kale", "https://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Boerenkool.jpg/1200px-Boerenkool.jpg", "Kale", 1000, 8800m },
                    { 21, 4, "Fresh Button Mushroom", "https://www.thespruceeats.com/thmb/PDnFtFMkfMsRBC1XqhCv0OP-J6I=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/what-are-button-mushrooms-5197530-hero-06-3d46a10b9e924f67849d5e7a049a6a2d.jpg", "Button Mushroom", 1000, 8800m },
                    { 22, 4, "Fresh Shiitake Mushroom", "https://cdn.britannica.com/47/182647-050-EA329FC3/shiitake-mushrooms.jpg", "Shiitake Mushroom", 1000, 8800m },
                    { 23, 4, "Fresh Portobello Mushroom", "https://upload.wikimedia.org/wikipedia/commons/3/3e/Portobello_mushrooms.jpg", "Portobello Mushroom", 1000, 8800m },
                    { 24, 4, "Fresh Morel Mushroom", "https://static01.nyt.com/images/2022/04/11/science/00SCI-MORELS3/merlin_205361283_e07e1753-e0bd-4eff-8c45-35442cb8c8d1-mediumSquareAt3X.jpg", "Morel Mushroom", 1000, 8800m },
                    { 25, 4, "Fresh Chanterelle Mushroom", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9a/Chanterelle_Cantharellus_cibarius.jpg/1023px-Chanterelle_Cantharellus_cibarius.jpg", "Chanterelle Mushroom", 1000, 8800m },
                    { 26, 5, "Fresh basil", "https://images.pexels.com/photos/1087902/pexels-photo-1087902.jpeg?cs=srgb&dl=pexels-monicore-1087902.jpg&fm=jpg", "Basil", 1000, 8800m },
                    { 27, 5, "Fresh Parsley", "https://cdn.britannica.com/63/193863-050-0EC30803/Parsley.jpg", "Parsley", 1000, 8800m },
                    { 28, 5, "Fresh Cilantro", "https://images.cookforyourlife.org/wp-content/uploads/2018/08/shutterstock_224264125-min.jpg", "Cilantro", 1000, 8800m },
                    { 29, 5, "Fresh Rosemary", "https://m.media-amazon.com/images/I/61L6xhYXiuL._AC_UF1000,1000_QL80_.jpg", "Rosemary", 1000, 8800m },
                    { 30, 5, "Fresh Mint", "https://assets.epicurious.com/photos/5763132cff66dde1456dfed0/4:3/w_1768,h_1326,c_limit/Mint_Leaves.jpg", "Mint", 1000, 8800m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserAccountId",
                table: "Comments",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
