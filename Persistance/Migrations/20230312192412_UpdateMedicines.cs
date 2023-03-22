using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMedicines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Producer",
                table: "Medicines",
                newName: "ProducerCountry");

            migrationBuilder.AddColumn<string>(
                name: "ProducerCompanyName",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProducerCompanyName",
                value: "Zeba");

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProducerCompanyName",
                value: "Beba");

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProducerCompanyName",
                value: "Maxima");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProducerCompanyName",
                table: "Medicines");

            migrationBuilder.RenameColumn(
                name: "ProducerCountry",
                table: "Medicines",
                newName: "Producer");
        }
    }
}
