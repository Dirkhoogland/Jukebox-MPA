using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jukebox_MPA_ASP.NET.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.ID);
                    
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Playlist = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Song = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    User = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Savedsongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Song = table.Column<string>(type: "int", nullable: true),
                    User = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Songname = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Song = table.Column<string>(type: "int", nullable: true),
                    Genre = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Author = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.ID);
                }) ;  
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Savedsongs");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
