using Microsoft.EntityFrameworkCore.Migrations;

namespace movies_catalogue.Data.Migrations
{
    public partial class sfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesInFavorites_Favorites_FavoritesId",
                table: "MoviesInFavorites");

            migrationBuilder.DropIndex(
                name: "IX_MoviesInFavorites_FavoritesId",
                table: "MoviesInFavorites");

            migrationBuilder.DropColumn(
                name: "FavoritesId",
                table: "MoviesInFavorites");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesInFavorites_FavoriteId",
                table: "MoviesInFavorites",
                column: "FavoriteId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesInFavorites_Favorites_FavoriteId",
                table: "MoviesInFavorites",
                column: "FavoriteId",
                principalTable: "Favorites",
                principalColumn: "FavoriteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesInFavorites_Favorites_FavoriteId",
                table: "MoviesInFavorites");

            migrationBuilder.DropIndex(
                name: "IX_MoviesInFavorites_FavoriteId",
                table: "MoviesInFavorites");

            migrationBuilder.AddColumn<int>(
                name: "FavoritesId",
                table: "MoviesInFavorites",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoviesInFavorites_FavoritesId",
                table: "MoviesInFavorites",
                column: "FavoritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesInFavorites_Favorites_FavoritesId",
                table: "MoviesInFavorites",
                column: "FavoritesId",
                principalTable: "Favorites",
                principalColumn: "FavoriteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
