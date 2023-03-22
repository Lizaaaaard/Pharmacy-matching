using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMedcToPharmModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Medicines");

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
                keyColumns: new[] { "MedcId", "PharmId" },
                keyValues: new object[] { 1, 1 },
                column: "Price",
                value: 8.25m);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumns: new[] { "MedcId", "PharmId" },
                keyValues: new object[] { 3, 1 },
                column: "Price",
                value: 6.5m);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumns: new[] { "MedcId", "PharmId" },
                keyValues: new object[] { 1, 2 },
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumns: new[] { "MedcId", "PharmId" },
                keyValues: new object[] { 3, 2 },
                column: "Price",
                value: 3.2m);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumns: new[] { "MedcId", "PharmId" },
                keyValues: new object[] { 2, 3 },
                column: "Price",
                value: 10.99m);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumns: new[] { "MedcId", "PharmId" },
                keyValues: new object[] { 3, 3 },
                column: "Price",
                value: 15.79m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "MedcToPharm");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Medicines",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 5.6m);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 3.2m);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 8.25m);
        }
    }
}
