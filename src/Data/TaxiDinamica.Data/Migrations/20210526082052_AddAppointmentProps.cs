using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiDinamica.Data.Migrations
{
    public partial class AddAppointmentProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressEnd",
                table: "Appointments",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressStart",
                table: "Appointments",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Appointments",
                maxLength: 700,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Appointments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressEnd",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AddressStart",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Appointments");
        }
    }
}
