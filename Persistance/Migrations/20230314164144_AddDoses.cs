using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddDoses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MedcToPharm",
                table: "MedcToPharm");

            migrationBuilder.DeleteData(
                table: "MedcToPharm",
                keyColumns: new[] { "MedcId", "PharmId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MedcToPharm",
                keyColumns: new[] { "MedcId", "PharmId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "MedcToPharm",
                keyColumns: new[] { "MedcId", "PharmId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MedcToPharm",
                keyColumns: new[] { "MedcId", "PharmId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "MedcToPharm",
                keyColumns: new[] { "MedcId", "PharmId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "MedcToPharm",
                keyColumns: new[] { "MedcId", "PharmId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "MedcToPharm");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "MedcToPharm");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MedcToPharm",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedcToPharm",
                table: "MedcToPharm",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Doses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedcToPharmId = table.Column<int>(type: "int", nullable: false),
                    Package = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doses_MedcToPharm_MedcToPharmId",
                        column: x => x.MedcToPharmId,
                        principalTable: "MedcToPharm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MedcToPharm",
                columns: new[] { "Id", "MedcId", "PharmId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 3, 1 },
                    { 3, 1, 2 },
                    { 4, 3, 2 },
                    { 5, 3, 3 },
                    { 6, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Doses",
                columns: new[] { "Id", "Amount", "MedcToPharmId", "Package", "Price" },
                values: new object[,]
                {
                    { 1, 4, 1, "tablets 50mg in pack no.30", 8.25m },
                    { 2, 2, 1, "tablets 100mg in pack no.60", 13.99m },
                    { 3, 11, 2, "tablets 50mg in pack no.30", 8.25m },
                    { 4, 8, 3, "tablets 100mg in pack no.60", 14.14m },
                    { 5, 1, 4, "tablets 150mg in pack no.70", 4.99m },
                    { 6, 0, 4, "tablets 100mg in pack no.60", 7m },
                    { 7, 5, 5, "tablets 50mg in pack no.30", 10.33m },
                    { 8, 0, 6, "tablets 50mg in pack no.30", 1.5m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedcToPharm_PharmId",
                table: "MedcToPharm",
                column: "PharmId");

            migrationBuilder.CreateIndex(
                name: "IX_Doses_MedcToPharmId",
                table: "Doses",
                column: "MedcToPharmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedcToPharm",
                table: "MedcToPharm");

            migrationBuilder.DropIndex(
                name: "IX_MedcToPharm_PharmId",
                table: "MedcToPharm");

            migrationBuilder.DeleteData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MedcToPharm",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MedcToPharm",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "MedcToPharm",
                type: "int",
                nullable: false,
                defaultValue: 5);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "MedcToPharm",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedcToPharm",
                table: "MedcToPharm",
                columns: new[] { "PharmId", "MedcId" });

            migrationBuilder.InsertData(
                table: "MedcToPharm",
                columns: new[] { "MedcId", "PharmId", "Amount", "Id", "Price" },
                values: new object[,]
                {
                    { 1, 1, 15, 1, 8.25m },
                    { 3, 1, 9, 2, 6.5m }
                });

            migrationBuilder.InsertData(
                table: "MedcToPharm",
                columns: new[] { "MedcId", "PharmId", "Id", "Price" },
                values: new object[] { 1, 2, 3, 0m });

            migrationBuilder.InsertData(
                table: "MedcToPharm",
                columns: new[] { "MedcId", "PharmId", "Amount", "Id", "Price" },
                values: new object[,]
                {
                    { 3, 2, 10, 4, 3.2m },
                    { 2, 3, 10, 6, 10.99m },
                    { 3, 3, 7, 5, 15.79m }
                });
        }
    }
}
