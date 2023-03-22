using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPrescription = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedcToPharm",
                columns: table => new
                {
                    PharmId = table.Column<int>(type: "int", nullable: false),
                    MedcId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false, defaultValue: 5)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedcToPharm", x => new { x.PharmId, x.MedcId });
                    table.ForeignKey(
                        name: "FK_MedcToPharm_Medicines_MedcId",
                        column: x => x.MedcId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedcToPharm_Pharmacies_PharmId",
                        column: x => x.PharmId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "Description", "IsPrescription", "Name", "Price" },
                values: new object[,]
                {
                        { 1, "It is most commonly used as a pain killer, or to reduce fever or inflammation. It also has an anti-platelet effect - it reduces the number of platelets in the blood which reduces blood clotting- in that function it is used to prevent heart attacks.", false, "Aspirin", 5.6m },
                        { 2, "Pharmacological group of the substance Iodine:macro- and microelements, antiseptics and disinfectants, local irritating agents in combinations, other hypolipidemic agents", false, "Iodine", 3.2m },
                        { 3, "Ibuprofen has a rapid analgesic, antipyretic and anti-inflammatory effect. In addition, ibuprofen reversibly inhibits platelet aggregation.", false, "ibuprofen", 8.25m }
                });

            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "Id", "Address", "Description", "Name" },
                values: new object[,]
                {
                        { 1, "35, Sherwood street", "Working hours: 7:00 - 22:00, no lunches, no days off", "Pharmacy №1" },
                        { 2, "167, Gray-Village avenue", "Working hours: 00 - 24", "Adele" },
                        { 3, "45, Adreas street", "Working hours: 8:30 - 23:00, lunch break: 13:00 - 13:45", "Pharmacy №16" }
                });

            migrationBuilder.InsertData(
                table: "MedcToPharm",
                columns: new[] { "MedcId", "PharmId", "Amount", "Id" },
                values: new object[,]
                {
                        { 1, 1, 15, 1 },
                        { 3, 1, 9, 2 }
                });

            migrationBuilder.InsertData(
                table: "MedcToPharm",
                columns: new[] { "MedcId", "PharmId", "Id" },
                values: new object[] { 1, 2, 3 });

            migrationBuilder.InsertData(
                table: "MedcToPharm",
                columns: new[] { "MedcId", "PharmId", "Amount", "Id" },
                values: new object[,]
                {
                        { 3, 2, 10, 4 },
                        { 2, 3, 10, 6 },
                        { 3, 3, 7, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedcToPharm_MedcId",
                table: "MedcToPharm",
                column: "MedcId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedcToPharm");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Pharmacies");
        }
    }
}
