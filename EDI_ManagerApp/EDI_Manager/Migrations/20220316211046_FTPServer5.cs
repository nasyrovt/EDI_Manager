using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDI_Manager.Migrations
{
    public partial class FTPServer5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_FTPServers_FTPServerId",
                table: "Feeds");

            migrationBuilder.AlterColumn<int>(
                name: "FTPServerId",
                table: "Feeds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_FTPServers_FTPServerId",
                table: "Feeds",
                column: "FTPServerId",
                principalTable: "FTPServers",
                principalColumn: "FTPServerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_FTPServers_FTPServerId",
                table: "Feeds");

            migrationBuilder.AlterColumn<int>(
                name: "FTPServerId",
                table: "Feeds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_FTPServers_FTPServerId",
                table: "Feeds",
                column: "FTPServerId",
                principalTable: "FTPServers",
                principalColumn: "FTPServerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
