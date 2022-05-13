using Microsoft.EntityFrameworkCore.Migrations;

namespace movies_catalogue.Data.Migrations
{
    public partial class personrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "role",
                table: "People",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "People");
        }
    }
}
