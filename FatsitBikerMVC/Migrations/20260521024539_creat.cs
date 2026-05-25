using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FatsitBikerMVC.Migrations
{
    /// <inheritdoc />
    public partial class creat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Engine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Power = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Xe tay ga" },
                    { 2, "Xe số" },
                    { 3, "Xe côn tay" },
                    { 4, "Xe điện" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Desc", "Engine", "Images", "Name", "Power", "Price", "Weight" },
                values: new object[,]
                {
                    { 1, 1, "Mô tả chi tiết cho Honda SH 150i", "125cc", "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]", "Honda SH 150i", "10 HP", "34000000", "110 kg" },
                    { 2, 1, "Mô tả chi tiết cho Honda Vision", "125cc", "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]", "Honda Vision", "10 HP", "34000000", "110 kg" },
                    { 3, 1, "Mô tả chi tiết cho Honda Air Blade", "125cc", "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]", "Honda Air Blade", "10 HP", "84000000", "110 kg" },
                    { 4, 1, "Mô tả chi tiết cho Honda Lead", "125cc", "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]", "Honda Lead", "10 HP", "65000000", "110 kg" },
                    { 5, 1, "Mô tả chi tiết cho Honda Vario", "125cc", "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]", "Honda Vario", "10 HP", "85000000", "110 kg" },
                    { 6, 1, "Mô tả chi tiết cho Yamaha NVX", "125cc", "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]", "Yamaha NVX", "10 HP", "87000000", "110 kg" },
                    { 7, 1, "Mô tả chi tiết cho Yamaha Grande", "125cc", "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]", "Yamaha Grande", "10 HP", "41000000", "110 kg" },
                    { 8, 1, "Mô tả chi tiết cho Yamaha Latte", "125cc", "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]", "Yamaha Latte", "10 HP", "81000000", "110 kg" },
                    { 9, 1, "Mô tả chi tiết cho Yamaha FreeGo", "125cc", "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]", "Yamaha FreeGo", "10 HP", "48000000", "110 kg" },
                    { 10, 1, "Mô tả chi tiết cho Vespa Sprint", "125cc", "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]", "Vespa Sprint", "10 HP", "65000000", "110 kg" },
                    { 11, 1, "Mô tả chi tiết cho Vespa Primavera", "125cc", "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]", "Vespa Primavera", "10 HP", "46000000", "110 kg" },
                    { 12, 1, "Mô tả chi tiết cho Piaggio Medley", "125cc", "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]", "Piaggio Medley", "10 HP", "57000000", "110 kg" },
                    { 13, 1, "Mô tả chi tiết cho Piaggio Liberty", "125cc", "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]", "Piaggio Liberty", "10 HP", "45000000", "110 kg" },
                    { 14, 2, "Mô tả chi tiết cho Honda Wave Alpha", "110cc", "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]", "Honda Wave Alpha", "8 HP", "15000000", "95 kg" },
                    { 15, 2, "Mô tả chi tiết cho Honda Wave RSX", "110cc", "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]", "Honda Wave RSX", "8 HP", "18000000", "95 kg" },
                    { 16, 2, "Mô tả chi tiết cho Honda Blade", "110cc", "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]", "Honda Blade", "8 HP", "33000000", "95 kg" },
                    { 17, 2, "Mô tả chi tiết cho Honda Future", "110cc", "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]", "Honda Future", "8 HP", "19000000", "95 kg" },
                    { 18, 2, "Mô tả chi tiết cho Yamaha Sirius", "110cc", "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]", "Yamaha Sirius", "8 HP", "37000000", "95 kg" },
                    { 19, 2, "Mô tả chi tiết cho Yamaha Jupiter", "110cc", "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]", "Yamaha Jupiter", "8 HP", "36000000", "95 kg" },
                    { 20, 2, "Mô tả chi tiết cho SYM Elegant", "110cc", "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]", "SYM Elegant", "8 HP", "23000000", "95 kg" },
                    { 21, 2, "Mô tả chi tiết cho SYM Galaxy", "110cc", "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]", "SYM Galaxy", "8 HP", "17000000", "95 kg" },
                    { 22, 2, "Mô tả chi tiết cho Honda Super Cub", "110cc", "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]", "Honda Super Cub", "8 HP", "28000000", "95 kg" },
                    { 23, 2, "Mô tả chi tiết cho Yamaha Finn", "110cc", "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]", "Yamaha Finn", "8 HP", "23000000", "95 kg" },
                    { 24, 2, "Mô tả chi tiết cho SYM Angela", "110cc", "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]", "SYM Angela", "8 HP", "32000000", "95 kg" },
                    { 25, 2, "Mô tả chi tiết cho SYM Star SR", "110cc", "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]", "SYM Star SR", "8 HP", "29000000", "95 kg" },
                    { 26, 3, "Mô tả chi tiết cho Yamaha Exciter 155", "150cc - 1000cc", "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]", "Yamaha Exciter 155", "15 - 200 HP", "327000000", "130 - 200 kg" },
                    { 27, 3, "Mô tả chi tiết cho Honda Winner X", "150cc - 1000cc", "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]", "Honda Winner X", "15 - 200 HP", "378000000", "130 - 200 kg" },
                    { 28, 3, "Mô tả chi tiết cho Suzuki Raider", "150cc - 1000cc", "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]", "Suzuki Raider", "15 - 200 HP", "385000000", "130 - 200 kg" },
                    { 29, 3, "Mô tả chi tiết cho Suzuki Satria", "150cc - 1000cc", "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]", "Suzuki Satria", "15 - 200 HP", "225000000", "130 - 200 kg" },
                    { 30, 3, "Mô tả chi tiết cho Yamaha MT-15", "150cc - 1000cc", "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]", "Yamaha MT-15", "15 - 200 HP", "156000000", "130 - 200 kg" },
                    { 31, 3, "Mô tả chi tiết cho Honda CBR150R", "150cc - 1000cc", "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]", "Honda CBR150R", "15 - 200 HP", "357000000", "130 - 200 kg" },
                    { 32, 3, "Mô tả chi tiết cho Yamaha R15", "150cc - 1000cc", "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]", "Yamaha R15", "15 - 200 HP", "140000000", "130 - 200 kg" },
                    { 33, 3, "Mô tả chi tiết cho Suzuki GSX-R150", "150cc - 1000cc", "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]", "Suzuki GSX-R150", "15 - 200 HP", "280000000", "130 - 200 kg" },
                    { 34, 3, "Mô tả chi tiết cho Honda MSX 125", "150cc - 1000cc", "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]", "Honda MSX 125", "15 - 200 HP", "265000000", "130 - 200 kg" },
                    { 35, 3, "Mô tả chi tiết cho Kawasaki Z1000", "150cc - 1000cc", "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]", "Kawasaki Z1000", "15 - 200 HP", "160000000", "130 - 200 kg" },
                    { 36, 3, "Mô tả chi tiết cho Ducati Panigale", "150cc - 1000cc", "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]", "Ducati Panigale", "15 - 200 HP", "395000000", "130 - 200 kg" },
                    { 37, 3, "Mô tả chi tiết cho Yamaha MT-09", "150cc - 1000cc", "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]", "Yamaha MT-09", "15 - 200 HP", "46000000", "130 - 200 kg" },
                    { 38, 4, "Mô tả chi tiết cho VinFast Feliz S", "Điện", "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]", "VinFast Feliz S", "1000W - 3000W", "41000000", "90 - 120 kg" },
                    { 39, 4, "Mô tả chi tiết cho VinFast Klara S", "Điện", "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]", "VinFast Klara S", "1000W - 3000W", "39000000", "90 - 120 kg" },
                    { 40, 4, "Mô tả chi tiết cho VinFast Vento S", "Điện", "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]", "VinFast Vento S", "1000W - 3000W", "41000000", "90 - 120 kg" },
                    { 41, 4, "Mô tả chi tiết cho VinFast Theon S", "Điện", "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]", "VinFast Theon S", "1000W - 3000W", "54000000", "90 - 120 kg" },
                    { 42, 4, "Mô tả chi tiết cho VinFast Evo 200", "Điện", "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]", "VinFast Evo 200", "1000W - 3000W", "39000000", "90 - 120 kg" },
                    { 43, 4, "Mô tả chi tiết cho Yadea Odora", "Điện", "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]", "Yadea Odora", "1000W - 3000W", "29000000", "90 - 120 kg" },
                    { 44, 4, "Mô tả chi tiết cho Yadea Xmen", "Điện", "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]", "Yadea Xmen", "1000W - 3000W", "30000000", "90 - 120 kg" },
                    { 45, 4, "Mô tả chi tiết cho Pega S", "Điện", "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]", "Pega S", "1000W - 3000W", "49000000", "90 - 120 kg" },
                    { 46, 4, "Mô tả chi tiết cho Dat Bike Weaver", "Điện", "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]", "Dat Bike Weaver", "1000W - 3000W", "31000000", "90 - 120 kg" },
                    { 47, 4, "Mô tả chi tiết cho Dat Bike Weaver 200", "Điện", "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]", "Dat Bike Weaver 200", "1000W - 3000W", "35000000", "90 - 120 kg" },
                    { 48, 4, "Mô tả chi tiết cho Dat Bike Weaver++", "Điện", "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]", "Dat Bike Weaver++", "1000W - 3000W", "61000000", "90 - 120 kg" },
                    { 49, 4, "Mô tả chi tiết cho Yadea Ulike", "Điện", "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]", "Yadea Ulike", "1000W - 3000W", "24000000", "90 - 120 kg" },
                    { 50, 4, "Mô tả chi tiết cho Dibao Gogo", "Điện", "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]", "Dibao Gogo", "1000W - 3000W", "61000000", "90 - 120 kg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
