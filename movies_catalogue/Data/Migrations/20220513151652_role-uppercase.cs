using Microsoft.EntityFrameworkCore.Migrations;

namespace movies_catalogue.Data.Migrations
{
    public partial class roleuppercase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "People",
                newName: "Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "People",
                newName: "role");
        }
    }
}
