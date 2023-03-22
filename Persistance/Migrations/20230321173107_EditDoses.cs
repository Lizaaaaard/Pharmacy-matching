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
            migrationBuilder.DropForeignKey(
                name: "FK_Doses_MedcToPharm_MedcToPharmId",
                table: "Doses");

            migrationBuilder.DropIndex(
                name: "IX_Doses_MedcToPharmId",
                table: "Doses");

            migrationBuilder.DropColumn(
                name: "MedcToPharmId",
                table: "Doses");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MedcToPharm",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DoseId",
                table: "MedcToPharm",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 1,
                column: "DoseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DoseId", "MedcId" },
                values: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 3,
                column: "DoseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 4,
                column: "DoseId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DoseId", "MedcId", "PharmId" },
                values: new object[] { 1, 2, 2 });

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DoseId", "MedcId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "MedcToPharm",
                columns: new[] { "Id", "DoseId", "MedcId", "PharmId" },
                values: new object[] { 7, 1, 2, 3 });

            migrationBuilder.AddForeignKey(
                name: "FK_MedcToPharm_Doses_Id",
                table: "MedcToPharm",
                column: "Id",
                principalTable: "Doses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedcToPharm_Doses_Id",
                table: "MedcToPharm");

            migrationBuilder.DeleteData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "DoseId",
                table: "MedcToPharm");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MedcToPharm",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MedcToPharmId",
                table: "Doses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 1,
                column: "MedcToPharmId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 2,
                column: "MedcToPharmId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 3,
                column: "MedcToPharmId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 4,
                column: "MedcToPharmId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 5,
                column: "MedcToPharmId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 6,
                column: "MedcToPharmId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 7,
                column: "MedcToPharmId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 8,
                column: "MedcToPharmId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 2,
                column: "MedcId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MedcId", "PharmId" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 6,
                column: "MedcId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Doses_MedcToPharmId",
                table: "Doses",
                column: "MedcToPharmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doses_MedcToPharm_MedcToPharmId",
                table: "Doses",
                column: "MedcToPharmId",
                principalTable: "MedcToPharm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
