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
                name: "Doses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Package = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPrescription = table.Column<bool>(type: "bit", nullable: false),
                    ProducerCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProducerCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseForm = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedcToPharm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmId = table.Column<int>(type: "int", nullable: false),
                    MedcId = table.Column<int>(type: "int", nullable: false),
                    DoseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedcToPharm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedcToPharm_Doses_DoseId",
                        column: x => x.DoseId,
                        principalTable: "Doses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Doses",
                columns: new[] { "Id", "Amount", "Package", "Price" },
                values: new object[,]
                {
                    { 1, 4, "tablets 50mg in pack no.30", 8.25m },
                    { 2, 2, "tablets 100mg in pack no.60", 13.99m },
                    { 3, 11, "tablets 50mg in pack no.30", 8.25m },
                    { 4, 8, "tablets 100mg in pack no.60", 14.14m },
                    { 5, 1, "tablets 150mg in pack no.70", 4.99m },
                    { 6, 0, "tablets 100mg in pack no.60", 7m },
                    { 7, 5, "tablets 50mg in pack no.30", 10.33m },
                    { 8, 0, "tablets 50mg in pack no.30", 1.5m }
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "Description", "IsPrescription", "Name", "ProducerCompanyName", "ProducerCountry", "ReleaseForm" },
                values: new object[,]
                {
                    { 1, "It is most commonly used as a pain killer, or to reduce fever or inflammation. It also has an anti-platelet effect - it reduces the number of platelets in the blood which reduces blood clotting- in that function it is used to prevent heart attacks.", false, "Aspirin", "Zeba", "Germany", "tablets" },
                    { 2, "Pharmacological group of the substance Iodine:macro- and microelements, antiseptics and disinfectants, local irritating agents in combinations, other hypolipidemic agents", false, "Iodine", "Beba", "Belarus", "tablets" },
                    { 3, "Ibuprofen has a rapid analgesic, antipyretic and anti-inflammatory effect. In addition, ibuprofen reversibly inhibits platelet aggregation.", false, "ibuprofen", "Maxima", "Germany", "capsules" }
                });

            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "Id", "Address", "Description", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "35, Sherwood street", "Working hours: 7:00 - 22:00, no lunches, no days off", "Pharmacy №1", "1234567890128" },
                    { 2, "167, Gray-Village avenue", "Working hours: 00 - 24", "Adele", "1233367890128" },
                    { 3, "45, Andreas street", "Working hours: 8:30 - 23:00, lunch break: 13:00 - 13:45", "Pharmacy №16", "1234567896668" }
                });

            migrationBuilder.InsertData(
                table: "MedcToPharm",
                columns: new[] { "Id", "DoseId", "MedcId", "PharmId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 3, 1, 1 },
                    { 3, 1, 1, 2 },
                    { 4, 3, 3, 2 },
                    { 5, 1, 2, 2 },
                    { 6, 1, 3, 3 },
                    { 7, 1, 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedcToPharm_DoseId",
                table: "MedcToPharm",
                column: "DoseId");

            migrationBuilder.CreateIndex(
                name: "IX_MedcToPharm_MedcId",
                table: "MedcToPharm",
                column: "MedcId");

            migrationBuilder.CreateIndex(
                name: "IX_MedcToPharm_PharmId",
                table: "MedcToPharm",
                column: "PharmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedcToPharm");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Doses");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Pharmacies");
        }
    }
}
