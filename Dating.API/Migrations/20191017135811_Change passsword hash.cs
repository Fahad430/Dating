using Microsoft.EntityFrameworkCore.Migrations;

namespace Dating.API.Migrations
{
    public partial class Changepassswordhash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Passwordsalt",
                table: "Users",
                newName: "PasswordSalt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "Users",
                newName: "Passwordsalt");
        }
    }
}
