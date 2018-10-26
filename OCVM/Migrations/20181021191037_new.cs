using Microsoft.EntityFrameworkCore.Migrations;

namespace OCVM.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "PersonalDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentLocation",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExpectedSalary",
                table: "Contacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PermanentAddress",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "presentAddress",
                table: "Contacts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "PersonalDetail");

            migrationBuilder.DropColumn(
                name: "CurrentLocation",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ExpectedSalary",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "PermanentAddress",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "presentAddress",
                table: "Contacts");
        }
    }
}
