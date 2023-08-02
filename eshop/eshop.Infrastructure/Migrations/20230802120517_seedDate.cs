using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eshop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Elektronik" },
                    { 2, "Kırtasiye" },
                    { 3, "Müzik" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "Discount", "ImageUrl", "Name", "Price", "StockCount", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, null, "Laptop Dell XPS 13", 0.20m, "https://cdn.dsmcdn.com/ty922/product/media/images/20230530/18/371725042/263518095/1/1_org.jpg", "Dell XPS", 65000m, 100, null },
                    { 2, 2, null, "Beyaz Tahta", 0.20m, "https://cdn.dsmcdn.com/ty922/product/media/images/20230530/18/371725042/263518095/1/1_org.jpg", "BT 1000", 570m, 100, null },
                    { 3, 3, null, "Yamaha Drum Set", 0.20m, "https://cdn.dsmcdn.com/ty922/product/media/images/20230530/18/371725042/263518095/1/1_org.jpg", "Drum set...", 65000m, 100, null },
                    { 4, 1, null, "Mac Book Pro ", 0.20m, "https://cdn.dsmcdn.com/ty922/product/media/images/20230530/18/371725042/263518095/1/1_org.jpg", "M2", 120000m, 100, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
