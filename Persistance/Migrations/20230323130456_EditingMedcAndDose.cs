using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class EditingMedcAndDose : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseForm",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Doses");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "MedcToPharm",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReleaseForm",
                table: "Doses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Package", "ReleaseForm" },
                values: new object[] { "tablets 50mg in pack no.40", "tablets" });

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Package", "ReleaseForm" },
                values: new object[] { "syrop 1000ml in pack", "syrop" });

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Package", "ReleaseForm" },
                values: new object[] { "capsules 50mg in pack no.25", "capsules" });

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReleaseForm",
                value: "tablets");

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Package", "ReleaseForm" },
                values: new object[] { "capsules 150mg in pack no.70", "capsules" });

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Package", "ReleaseForm" },
                values: new object[] { "tablets 100mg in pack no.40", "tablets" });

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Package", "ReleaseForm" },
                values: new object[] { "tablets 50mg in pack no.35", "tablets" });

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 8,
                column: "ReleaseForm",
                value: "tablets");

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 17);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 2,
                column: "Amount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 3,
                column: "Amount",
                value: 4);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 4,
                column: "Amount",
                value: 11);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 5,
                column: "Amount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 6,
                column: "Amount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 7,
                column: "Amount",
                value: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "MedcToPharm");

            migrationBuilder.DropColumn(
                name: "ReleaseForm",
                table: "Doses");

            migrationBuilder.AddColumn<string>(
                name: "ReleaseForm",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Doses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Amount", "Package" },
                values: new object[] { 4, "tablets 50mg in pack no.30" });

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amount", "Package" },
                values: new object[] { 2, "tablets 100mg in pack no.60" });

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Amount", "Package" },
                values: new object[] { 11, "tablets 50mg in pack no.30" });

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Amount",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Amount", "Package" },
                values: new object[] { 1, "tablets 150mg in pack no.70" });

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Amount", "Package" },
                values: new object[] { 0, "tablets 100mg in pack no.60" });

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Amount", "Package" },
                values: new object[] { 5, "tablets 50mg in pack no.30" });

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 8,
                column: "Amount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReleaseForm",
                value: "tablets");

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReleaseForm",
                value: "tablets");

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReleaseForm",
                value: "capsules");
        }
    }
}
