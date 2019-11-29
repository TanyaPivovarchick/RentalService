using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalService.DAL.Migrations
{
    public partial class AddKeyReturnTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "KeyReturnTime",
                table: "Reservations",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeyReturnTime",
                table: "Reservations");
        }
    }
}
