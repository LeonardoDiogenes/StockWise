using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockWise.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Eletrônicos" },
                    { 2, null, "Informática" },
                    { 3, null, "Celulares" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "Contact", "Name" },
                values: new object[,]
                {
                    { 1, "123 Tech Street, Tech City", "contact@techsupplier.com", "Tech Supplier Inc." },
                    { 2, "456 Fashion Avenue, Style City", "info@fashionsupplier.com", "Fashion Supplier Ltd." }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Image", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "admin@stockwise.com", "https://example.com/images/admin.jpg", "Admin", "admin123", "Admin" },
                    { 2, "user@stockwise.com", "https://example.com/images/user.jpg", "User", "user123", "User" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price", "StockQuantity", "SupplierId" },
                values: new object[,]
                {
                    { 1, 1, "A latest generation smartphone with advanced features.", "https://example.com/images/smartphone-x.jpg", "Smartphone X", 999.99000000000001, 50, null },
                    { 2, 1, "A high-performance laptop for professionals.", "https://example.com/images/laptop-pro.jpg", "Laptop Pro", 1499.99, 30, null },
                    { 3, 2, "A comfortable and stylish t-shirt.", "https://example.com/images/tshirt-casual.jpg", "T-Shirt Casual", 29.989999999999998, 100, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
