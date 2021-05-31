using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiDinamica.Data.Migrations
{
    public partial class AddColumnDriverMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DriverMessage",
                table: "Appointments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverMessage",
                table: "Appointments");
        }
    }
}
