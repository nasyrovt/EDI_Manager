using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDI_Manager.Migrations
{
    public partial class SshKeysAndFTPAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_FTPServers_FTPServerId",
                table: "Feeds");

            migrationBuilder.DropTable(
                name: "FTPServers");

            migrationBuilder.DropColumn(
                name: "FTPUserName",
                table: "Feeds");

            migrationBuilder.RenameColumn(
                name: "FTPServerId",
                table: "Feeds",
                newName: "FTPAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Feeds_FTPServerId",
                table: "Feeds",
                newName: "IX_Feeds_FTPAccountId");

            migrationBuilder.CreateTable(
                name: "FTPAccounts",
                columns: table => new
                {
                    FTPAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FTPHost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FTPUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FTPPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FTPDirectory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FTPType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FTPPort = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FTPAccounts", x => x.FTPAccountId);
                });

            migrationBuilder.CreateTable(
                name: "SSHKeys",
                columns: table => new
                {
                    SSHKeyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FTPHost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSHKeys", x => x.SSHKeyId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_FTPAccounts_FTPAccountId",
                table: "Feeds",
                column: "FTPAccountId",
                principalTable: "FTPAccounts",
                principalColumn: "FTPAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_FTPAccounts_FTPAccountId",
                table: "Feeds");

            migrationBuilder.DropTable(
                name: "FTPAccounts");

            migrationBuilder.DropTable(
                name: "SSHKeys");

            migrationBuilder.RenameColumn(
                name: "FTPAccountId",
                table: "Feeds",
                newName: "FTPServerId");

            migrationBuilder.RenameIndex(
                name: "IX_Feeds_FTPAccountId",
                table: "Feeds",
                newName: "IX_Feeds_FTPServerId");

            migrationBuilder.AddColumn<string>(
                name: "FTPUserName",
                table: "Feeds",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FTPServers",
                columns: table => new
                {
                    FTPServerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FTPServerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SSHKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FTPServers", x => x.FTPServerId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_FTPServers_FTPServerId",
                table: "Feeds",
                column: "FTPServerId",
                principalTable: "FTPServers",
                principalColumn: "FTPServerId");
        }
    }
}
