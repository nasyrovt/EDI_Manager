using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDI_Manager.Migrations
{
    public partial class FTPServer3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FTPServerName",
                table: "Feeds");

            migrationBuilder.AddColumn<int>(
                name: "FTPServerId",
                table: "Feeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_FTPServerId",
                table: "Feeds",
                column: "FTPServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_FTPServers_FTPServerId",
                table: "Feeds",
                column: "FTPServerId",
                principalTable: "FTPServers",
                principalColumn: "FTPServerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_FTPServers_FTPServerId",
                table: "Feeds");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_FTPServerId",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "FTPServerId",
                table: "Feeds");

            migrationBuilder.AddColumn<string>(
                name: "FTPServerName",
                table: "Feeds",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
