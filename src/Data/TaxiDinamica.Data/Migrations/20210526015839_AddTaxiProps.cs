using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiDinamica.Data.Migrations
{
    public partial class AddTaxiProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Partners",
                newName: "DriverName"
                );

            migrationBuilder.RenameColumn(
                name: "DIANUrl",
                table: "Partners",
                newName: "DocCedulaUrl");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Partners",
                newName: "Placa");

            migrationBuilder.RenameColumn(
                name: "Website",
                table: "Partners",
                newName: "DriverContact");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Partners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DocLicenciaUrl",
                table: "Partners",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocOperacionUrl",
                table: "Partners",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocPaseUrl",
                table: "Partners",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocSeguroUrl",
                table: "Partners",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocSoatUrl",
                table: "Partners",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocTarjetonUrl",
                table: "Partners",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocTecnoUrl",
                table: "Partners",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "DocCedulaUrl",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "DocLicenciaUrl",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "DocOperacionUrl",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "DocPaseUrl",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "DocSeguroUrl",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "DocSoatUrl",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "DocTarjetonUrl",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "DocTecnoUrl",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "DriverContact",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "DriverName",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "Partners");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Partners",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DIANUrl",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Partners",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(3500)", maxLength: 3500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_IsDeleted",
                table: "BlogPosts",
                column: "IsDeleted");
        }
    }
}
