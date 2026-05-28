using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FatsitBikerMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddProductImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 1, "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", 1 },
                    { 2, "https://images.unsplash.com/photo-1558981359-219d6364c9c8", 1 },
                    { 3, "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f", 2 },
                    { 4, "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e", 2 },
                    { 5, "https://images.unsplash.com/photo-1558981403-c5f9899a28bc", 3 },
                    { 6, "https://images.unsplash.com/photo-1558980394-0a37b363a516", 3 },
                    { 7, "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", 4 },
                    { 8, "https://images.unsplash.com/photo-1558981359-219d6364c9c8", 4 },
                    { 9, "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f", 5 },
                    { 10, "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e", 5 },
                    { 11, "https://images.unsplash.com/photo-1558981403-c5f9899a28bc", 6 },
                    { 12, "https://images.unsplash.com/photo-1558980394-0a37b363a516", 6 },
                    { 13, "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", 7 },
                    { 14, "https://images.unsplash.com/photo-1558981359-219d6364c9c8", 7 },
                    { 15, "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f", 8 },
                    { 16, "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e", 8 },
                    { 17, "https://images.unsplash.com/photo-1558981403-c5f9899a28bc", 9 },
                    { 18, "https://images.unsplash.com/photo-1558980394-0a37b363a516", 9 },
                    { 19, "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", 10 },
                    { 20, "https://images.unsplash.com/photo-1558981359-219d6364c9c8", 10 },
                    { 21, "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f", 11 },
                    { 22, "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e", 11 },
                    { 23, "https://images.unsplash.com/photo-1558981403-c5f9899a28bc", 12 },
                    { 24, "https://images.unsplash.com/photo-1558980394-0a37b363a516", 12 },
                    { 25, "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", 13 },
                    { 26, "https://images.unsplash.com/photo-1558981359-219d6364c9c8", 13 },
                    { 27, "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f", 14 },
                    { 28, "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e", 14 },
                    { 29, "https://images.unsplash.com/photo-1558981403-c5f9899a28bc", 15 },
                    { 30, "https://images.unsplash.com/photo-1558980394-0a37b363a516", 15 },
                    { 31, "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", 16 },
                    { 32, "https://images.unsplash.com/photo-1558981359-219d6364c9c8", 16 },
                    { 33, "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f", 17 },
                    { 34, "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e", 17 },
                    { 35, "https://images.unsplash.com/photo-1558981403-c5f9899a28bc", 18 },
                    { 36, "https://images.unsplash.com/photo-1558980394-0a37b363a516", 18 },
                    { 37, "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", 19 },
                    { 38, "https://images.unsplash.com/photo-1558981359-219d6364c9c8", 19 },
                    { 39, "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f", 20 },
                    { 40, "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e", 20 },
                    { 41, "https://images.unsplash.com/photo-1558981403-c5f9899a28bc", 21 },
                    { 42, "https://images.unsplash.com/photo-1558980394-0a37b363a516", 21 },
                    { 43, "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", 22 },
                    { 44, "https://images.unsplash.com/photo-1558981359-219d6364c9c8", 22 },
                    { 45, "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f", 23 },
                    { 46, "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e", 23 },
                    { 47, "https://images.unsplash.com/photo-1558981403-c5f9899a28bc", 24 },
                    { 48, "https://images.unsplash.com/photo-1558980394-0a37b363a516", 24 },
                    { 49, "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", 25 },
                    { 50, "https://images.unsplash.com/photo-1558981359-219d6364c9c8", 25 },
                    { 51, "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f", 26 },
                    { 52, "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e", 26 },
                    { 53, "https://images.unsplash.com/photo-1558981403-c5f9899a28bc", 27 },
                    { 54, "https://images.unsplash.com/photo-1558980394-0a37b363a516", 27 },
                    { 55, "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", 28 },
                    { 56, "https://images.unsplash.com/photo-1558981359-219d6364c9c8", 28 },
                    { 57, "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f", 29 },
                    { 58, "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e", 29 },
                    { 59, "https://images.unsplash.com/photo-1558981403-c5f9899a28bc", 30 },
                    { 60, "https://images.unsplash.com/photo-1558980394-0a37b363a516", 30 },
                    { 61, "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", 31 },
                    { 62, "https://images.unsplash.com/photo-1558981359-219d6364c9c8", 31 },
                    { 63, "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f", 32 },
                    { 64, "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e", 32 },
                    { 65, "https://images.unsplash.com/photo-1558981403-c5f9899a28bc", 33 },
                    { 66, "https://images.unsplash.com/photo-1558980394-0a37b363a516", 33 },
                    { 67, "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", 34 },
                    { 68, "https://images.unsplash.com/photo-1558981359-219d6364c9c8", 34 },
                    { 69, "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f", 35 },
                    { 70, "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e", 35 },
                    { 71, "https://images.unsplash.com/photo-1558981403-c5f9899a28bc", 36 },
                    { 72, "https://images.unsplash.com/photo-1558980394-0a37b363a516", 36 },
                    { 73, "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", 37 },
                    { 74, "https://images.unsplash.com/photo-1558981359-219d6364c9c8", 37 },
                    { 75, "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f", 38 },
                    { 76, "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e", 38 },
                    { 77, "https://images.unsplash.com/photo-1558981403-c5f9899a28bc", 39 },
                    { 78, "https://images.unsplash.com/photo-1558980394-0a37b363a516", 39 },
                    { 79, "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", 40 },
                    { 80, "https://images.unsplash.com/photo-1558981359-219d6364c9c8", 40 },
                    { 81, "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f", 41 },
                    { 82, "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e", 41 },
                    { 83, "https://images.unsplash.com/photo-1558981403-c5f9899a28bc", 42 },
                    { 84, "https://images.unsplash.com/photo-1558980394-0a37b363a516", 42 },
                    { 85, "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", 43 },
                    { 86, "https://images.unsplash.com/photo-1558981359-219d6364c9c8", 43 },
                    { 87, "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f", 44 },
                    { 88, "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e", 44 },
                    { 89, "https://images.unsplash.com/photo-1558981403-c5f9899a28bc", 45 },
                    { 90, "https://images.unsplash.com/photo-1558980394-0a37b363a516", 45 },
                    { 91, "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", 46 },
                    { 92, "https://images.unsplash.com/photo-1558981359-219d6364c9c8", 46 },
                    { 93, "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f", 47 },
                    { 94, "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e", 47 },
                    { 95, "https://images.unsplash.com/photo-1558981403-c5f9899a28bc", 48 },
                    { 96, "https://images.unsplash.com/photo-1558980394-0a37b363a516", 48 },
                    { 97, "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87", 49 },
                    { 98, "https://images.unsplash.com/photo-1558981359-219d6364c9c8", 49 },
                    { 99, "https://images.unsplash.com/photo-1449426468159-d96dbf08f19f", 50 },
                    { 100, "https://images.unsplash.com/photo-1615172282427-9a57ef2d142e", 50 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1568772585407-9361f9bf3a87\",\"https://images.unsplash.com/photo-1558981359-219d6364c9c8\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1449426468159-d96dbf08f19f\",\"https://images.unsplash.com/photo-1615172282427-9a57ef2d142e\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "Images",
                value: "[\"https://images.unsplash.com/photo-1558981403-c5f9899a28bc\",\"https://images.unsplash.com/photo-1558980394-0a37b363a516\"]");
        }
    }
}
