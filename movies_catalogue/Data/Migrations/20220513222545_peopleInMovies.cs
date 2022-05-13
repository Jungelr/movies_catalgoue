using Microsoft.EntityFrameworkCore.Migrations;

namespace movies_catalogue.Data.Migrations
{
    public partial class peopleInMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "People",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "PersonId");

            migrationBuilder.CreateTable(
                name: "PeopleInMovies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleInMovies", x => new { x.MovieId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_PeopleInMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleInMovies_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeopleInMovies_PersonId",
                table: "PeopleInMovies",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeopleInMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "ID");
        }
    }
}
