using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddNewElement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MedcToPharm",
                columns: new[] { "Id", "Amount", "DoseId", "MedcId", "PharmId", "Price" },
                values: new object[] { 8, 0, 1, 2, 1, 10m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
