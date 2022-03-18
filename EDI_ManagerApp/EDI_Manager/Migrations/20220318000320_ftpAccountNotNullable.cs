using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDI_Manager.Migrations
{
    public partial class ftpAccountNotNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_FTPAccounts_FTPAccountId",
                table: "Feeds");

            migrationBuilder.AlterColumn<int>(
                name: "FTPAccountId",
                table: "Feeds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_FTPAccounts_FTPAccountId",
                table: "Feeds",
                column: "FTPAccountId",
                principalTable: "FTPAccounts",
                principalColumn: "FTPAccountId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_FTPAccounts_FTPAccountId",
                table: "Feeds");

            migrationBuilder.AlterColumn<int>(
                name: "FTPAccountId",
                table: "Feeds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_FTPAccounts_FTPAccountId",
                table: "Feeds",
                column: "FTPAccountId",
                principalTable: "FTPAccounts",
                principalColumn: "FTPAccountId");
        }
    }
}
