using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class EditDoses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Doses");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "MedcToPharm",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 3.9m);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 10.33m);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 10.33m);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 12.5m);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 4.99m);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 7.3m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "MedcToPharm");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Doses",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 8.25m);

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 13.99m);

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 8.25m);

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 14.14m);

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 4.99m);

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 7m);

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 10.33m);

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 8,
                column: "Price",
                value: 1.5m);
        }
    }
}
