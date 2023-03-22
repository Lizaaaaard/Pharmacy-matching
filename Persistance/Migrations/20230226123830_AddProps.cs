using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Producer",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReleaseForm",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Producer", "ReleaseForm" },
                values: new object[] { "Germany", "tablets" });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Producer", "ReleaseForm" },
                values: new object[] { "Belarus", "tablets" });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Producer", "ReleaseForm" },
                values: new object[] { "Germany", "capsules" });

            migrationBuilder.UpdateData(
                table: "Pharmacies",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhoneNumber",
                value: "1234567890128");

            migrationBuilder.UpdateData(
                table: "Pharmacies",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhoneNumber",
                value: "1233367890128");

            migrationBuilder.UpdateData(
                table: "Pharmacies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "PhoneNumber" },
                values: new object[] { "45, Andreas street", "1234567896668" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "Producer",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "ReleaseForm",
                table: "Medicines");

            migrationBuilder.UpdateData(
                table: "Pharmacies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Address",
                value: "45, Adreas street");
        }
    }
}
