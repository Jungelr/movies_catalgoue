using Microsoft.EntityFrameworkCore.Migrations;

namespace movies_catalogue.Data.Migrations
{
    public partial class addedMoviesInFavorites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoviesInFavorites",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    FavoriteId = table.Column<int>(nullable: false),
                    FavoritesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesInFavorites", x => new { x.MovieId, x.FavoriteId });
                    table.ForeignKey(
                        name: "FK_MoviesInFavorites_Favorites_FavoritesId",
                        column: x => x.FavoritesId,
                        principalTable: "Favorites",
                        principalColumn: "FavoriteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoviesInFavorites_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviesInFavorites_FavoritesId",
                table: "MoviesInFavorites",
                column: "FavoritesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviesInFavorites");
        }
    }
}
