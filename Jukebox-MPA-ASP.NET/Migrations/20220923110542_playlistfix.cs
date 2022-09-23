using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jukebox_MPA_ASP.NET.Migrations
{
    public partial class playlistfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Playlist",
                table: "Playlists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Playlists",
                table: "Playlists",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Playlistname",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Playlistname = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    User = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlistname", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_Playlist",
                table: "Playlists",
                column: "Playlist");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Playlistname",
                table: "Playlists",
                column: "Playlist",
                principalTable: "Playlistname",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Playlistname",
                table: "Playlists");

            migrationBuilder.DropTable(
                name: "Playlistname");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Playlists",
                table: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_Playlist",
                table: "Playlists");

            migrationBuilder.AlterColumn<string>(
                name: "Playlist",
                table: "Playlists",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
