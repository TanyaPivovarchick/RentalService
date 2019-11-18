using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalService.DAL.Migrations
{
    public partial class AddIdToRentalPointCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalPointCar_Cars_CarId",
                table: "RentalPointCar");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalPointCar_RentalPoints_RentalPointId",
                table: "RentalPointCar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalPointCar",
                table: "RentalPointCar");

            migrationBuilder.DeleteData(
                table: "RentalPointCar",
                keyColumns: new[] { "RentalPointId", "CarId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RentalPointCar",
                keyColumns: new[] { "RentalPointId", "CarId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "RentalPointCar",
                keyColumns: new[] { "RentalPointId", "CarId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "RentalPointCar",
                keyColumns: new[] { "RentalPointId", "CarId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "RentalPointCar",
                keyColumns: new[] { "RentalPointId", "CarId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "RentalPointCar",
                keyColumns: new[] { "RentalPointId", "CarId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "RentalPointCar",
                keyColumns: new[] { "RentalPointId", "CarId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "RentalPointCar",
                keyColumns: new[] { "RentalPointId", "CarId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.RenameTable(
                name: "RentalPointCar",
                newName: "RentalPointCars");

            migrationBuilder.RenameIndex(
                name: "IX_RentalPointCar_CarId",
                table: "RentalPointCars",
                newName: "IX_RentalPointCars_CarId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RentalPointCars",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalPointCars",
                table: "RentalPointCars",
                column: "Id");

            migrationBuilder.InsertData(
                table: "RentalPointCars",
                columns: new[] { "Id", "CarId", "Cost", "Count", "RentalPointId" },
                values: new object[,]
                {
                    { 1, 1, 15.0, 10, 1 },
                    { 2, 1, 20.0, 15, 2 },
                    { 3, 2, 31.0, 23, 2 },
                    { 4, 2, 26.0, 17, 3 },
                    { 5, 2, 28.0, 11, 4 },
                    { 6, 3, 35.0, 5, 5 },
                    { 7, 4, 25.0, 7, 5 },
                    { 8, 5, 40.0, 9, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalPointCars_RentalPointId",
                table: "RentalPointCars",
                column: "RentalPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalPointCars_Cars_CarId",
                table: "RentalPointCars",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalPointCars_RentalPoints_RentalPointId",
                table: "RentalPointCars",
                column: "RentalPointId",
                principalTable: "RentalPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalPointCars_Cars_CarId",
                table: "RentalPointCars");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalPointCars_RentalPoints_RentalPointId",
                table: "RentalPointCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalPointCars",
                table: "RentalPointCars");

            migrationBuilder.DropIndex(
                name: "IX_RentalPointCars_RentalPointId",
                table: "RentalPointCars");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RentalPointCars");

            migrationBuilder.RenameTable(
                name: "RentalPointCars",
                newName: "RentalPointCar");

            migrationBuilder.RenameIndex(
                name: "IX_RentalPointCars_CarId",
                table: "RentalPointCar",
                newName: "IX_RentalPointCar_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalPointCar",
                table: "RentalPointCar",
                columns: new[] { "RentalPointId", "CarId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RentalPointCar_Cars_CarId",
                table: "RentalPointCar",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalPointCar_RentalPoints_RentalPointId",
                table: "RentalPointCar",
                column: "RentalPointId",
                principalTable: "RentalPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
