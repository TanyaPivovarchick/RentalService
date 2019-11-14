using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalService.DAL.Migrations
{
    public partial class AddRentalTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SeatCount = table.Column<int>(nullable: false),
                    FuelConsumption = table.Column<double>(nullable: false),
                    BrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentalPoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalPoints_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalPoints_RentalCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "RentalCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentalPointCar",
                columns: table => new
                {
                    RentalPointId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalPointCar", x => new { x.RentalPointId, x.CarId });
                    table.ForeignKey(
                        name: "FK_RentalPointCar_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalPointCar_RentalPoints_RentalPointId",
                        column: x => x.RentalPointId,
                        principalTable: "RentalPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "BMW" },
                    { 2, "Toyota" },
                    { 3, "Audi" },
                    { 4, "Bentley" },
                    { 5, "Nissan" }
                });

            migrationBuilder.InsertData(
                table: "RentalCompanies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Europcar" },
                    { 2, "Sixt" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "FuelConsumption", "Name", "SeatCount" },
                values: new object[,]
                {
                    { 1, 1, 9.0, "BMW X6", 5 },
                    { 2, 1, 7.9000000000000004, "BMW X7", 5 },
                    { 3, 1, 9.0999999999999996, "BMW X7", 7 },
                    { 4, 3, 6.0, "Audi Q7", 5 },
                    { 5, 5, 18.0, "Nissan Armada", 8 }
                });

            migrationBuilder.InsertData(
                table: "RentalPoints",
                columns: new[] { "Id", "Address", "CityId", "CompanyId" },
                values: new object[,]
                {
                    { 1, "GV DE LES CORTS CATALANES 680", 1, 1 },
                    { 2, "AVDA HISPANIDAD S/N LLEGADAS", 2, 1 },
                    { 3, "ED.GARE DO ORIENTE,LG.G-206", 4, 1 },
                    { 4, "Plaza de la Puerta del Mar,3", 3, 2 },
                    { 5, "Rua do Barreiro 65", 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "RentalPointCar",
                columns: new[] { "RentalPointId", "CarId", "Cost", "Count" },
                values: new object[,]
                {
                    { 1, 1, 15.0, 10 },
                    { 2, 1, 20.0, 15 },
                    { 2, 2, 31.0, 23 },
                    { 3, 2, 26.0, 17 },
                    { 4, 2, 28.0, 11 },
                    { 5, 3, 35.0, 5 },
                    { 5, 4, 25.0, 7 },
                    { 5, 5, 40.0, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalPointCar_CarId",
                table: "RentalPointCar",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalPoints_CityId",
                table: "RentalPoints",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalPoints_CompanyId",
                table: "RentalPoints",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalPointCar");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "RentalPoints");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "RentalCompanies");
        }
    }
}
