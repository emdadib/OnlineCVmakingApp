using Microsoft.EntityFrameworkCore.Migrations;

namespace OCVM.Migrations
{
    public partial class JobType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrepearedJob",
                table: "Contacts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrepearedJob",
                table: "Contacts");
        }
    }
}
