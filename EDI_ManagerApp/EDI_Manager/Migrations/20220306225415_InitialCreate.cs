using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDI_Manager.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ClientSurName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ClientAge = table.Column<int>(type: "int", nullable: false),
                    ClientAdress = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProfileCreationDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DeveloperSurName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DeveloperAge = table.Column<int>(type: "int", nullable: false),
                    DeveloperAdress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    HireDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.DeveloperId);
                });

            migrationBuilder.CreateTable(
                name: "FileTypes",
                columns: table => new
                {
                    FileTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileTypeName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTypes", x => x.FileTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_Files_FileTypes_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileTypes",
                        principalColumn: "FileTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feeds",
                columns: table => new
                {
                    FeedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    SourceFileId = table.Column<int>(type: "int", nullable: false),
                    TargetFileId = table.Column<int>(type: "int", nullable: false),
                    TargetEmails = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    FTPServerName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FTPUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeds", x => x.FeedId);
                    table.ForeignKey(
                        name: "FK_Feeds_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Feeds_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "DeveloperId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Feeds_Files_SourceFileId",
                        column: x => x.SourceFileId,
                        principalTable: "Files",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Feeds_Files_TargetFileId",
                        column: x => x.TargetFileId,
                        principalTable: "Files",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_ClientId",
                table: "Feeds",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_DeveloperId",
                table: "Feeds",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_SourceFileId",
                table: "Feeds",
                column: "SourceFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_TargetFileId",
                table: "Feeds",
                column: "TargetFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FileTypeId",
                table: "Files",
                column: "FileTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feeds");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "FileTypes");
        }
    }
}
