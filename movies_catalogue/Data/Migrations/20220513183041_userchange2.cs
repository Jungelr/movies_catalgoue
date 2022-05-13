using Microsoft.EntityFrameworkCore.Migrations;

namespace movies_catalogue.Data.Migrations
{
    public partial class userchange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserFavoritesFavoriteId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserFavoritesFavoriteId",
                table: "AspNetUsers",
                column: "UserFavoritesFavoriteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Favorites_UserFavoritesFavoriteId",
                table: "AspNetUsers",
                column: "UserFavoritesFavoriteId",
                principalTable: "Favorites",
                principalColumn: "FavoriteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Favorites_UserFavoritesFavoriteId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserFavoritesFavoriteId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserFavoritesFavoriteId",
                table: "AspNetUsers");
        }
    }
}
