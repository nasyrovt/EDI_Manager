using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDI_Manager.Migrations
{
    public partial class StructureChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_FeedFileChanges_FeedFileChangesId",
                table: "Feeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_FeedStatus_FeedStatusId",
                table: "Feeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_FileTypes_TargetFileTypeId",
                table: "Feeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileTypes_FileTypeId",
                table: "Files");

            migrationBuilder.DropTable(
                name: "FeedFileChanges");

            migrationBuilder.DropTable(
                name: "FeedStatus");

            migrationBuilder.DropTable(
                name: "FileTypes");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_FeedFileChangesId",
                table: "Feeds");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_FeedStatusId",
                table: "Feeds");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_TargetFileTypeId",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "FeedFileChangesId",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "FeedStatusId",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "DeveloperAge",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "DeveloperName",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "DeveloperSurName",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "ClientSurName",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "FileTypeId",
                table: "Files",
                newName: "FileMimeId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_FileTypeId",
                table: "Files",
                newName: "IX_Files_FileMimeId");

            migrationBuilder.RenameColumn(
                name: "TargetFileTypeId",
                table: "Feeds",
                newName: "TargetFileMimeId");

            migrationBuilder.RenameColumn(
                name: "DeveloperAdress",
                table: "Developers",
                newName: "DeveloperMail");

            migrationBuilder.RenameColumn(
                name: "ProfileCreationDate",
                table: "Clients",
                newName: "ContactPhoneNumbers");

            migrationBuilder.RenameColumn(
                name: "ClientAge",
                table: "Clients",
                newName: "ClientTaxId");

            migrationBuilder.RenameColumn(
                name: "ClientAdress",
                table: "Clients",
                newName: "ContactName");

            migrationBuilder.AlterColumn<int>(
                name: "FrequencyTimes",
                table: "Feeds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "InProduction",
                table: "Feeds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsChangesOnly",
                table: "Feeds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TargetFileTypeFileMimeId",
                table: "Feeds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeveloperFirstName",
                table: "Developers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeveloperLastName",
                table: "Developers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeveloperRole",
                table: "Developers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ClientName",
                table: "Clients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "ContactMails",
                table: "Clients",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FileMimes",
                columns: table => new
                {
                    FileMimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileMimeName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileMimes", x => x.FileMimeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_TargetFileTypeFileMimeId",
                table: "Feeds",
                column: "TargetFileTypeFileMimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_FileMimes_TargetFileTypeFileMimeId",
                table: "Feeds",
                column: "TargetFileTypeFileMimeId",
                principalTable: "FileMimes",
                principalColumn: "FileMimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_FileMimes_FileMimeId",
                table: "Files",
                column: "FileMimeId",
                principalTable: "FileMimes",
                principalColumn: "FileMimeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_FileMimes_TargetFileTypeFileMimeId",
                table: "Feeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileMimes_FileMimeId",
                table: "Files");

            migrationBuilder.DropTable(
                name: "FileMimes");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_TargetFileTypeFileMimeId",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "InProduction",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "IsChangesOnly",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "TargetFileTypeFileMimeId",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "DeveloperFirstName",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "DeveloperLastName",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "DeveloperRole",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "ContactMails",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "FileMimeId",
                table: "Files",
                newName: "FileTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_FileMimeId",
                table: "Files",
                newName: "IX_Files_FileTypeId");

            migrationBuilder.RenameColumn(
                name: "TargetFileMimeId",
                table: "Feeds",
                newName: "TargetFileTypeId");

            migrationBuilder.RenameColumn(
                name: "DeveloperMail",
                table: "Developers",
                newName: "DeveloperAdress");

            migrationBuilder.RenameColumn(
                name: "ContactPhoneNumbers",
                table: "Clients",
                newName: "ProfileCreationDate");

            migrationBuilder.RenameColumn(
                name: "ContactName",
                table: "Clients",
                newName: "ClientAdress");

            migrationBuilder.RenameColumn(
                name: "ClientTaxId",
                table: "Clients",
                newName: "ClientAge");

            migrationBuilder.AlterColumn<int>(
                name: "FrequencyTimes",
                table: "Feeds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeedFileChangesId",
                table: "Feeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FeedStatusId",
                table: "Feeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeveloperAge",
                table: "Developers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DeveloperName",
                table: "Developers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeveloperSurName",
                table: "Developers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HireDate",
                table: "Developers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ClientName",
                table: "Clients",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "ClientSurName",
                table: "Clients",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FeedFileChanges",
                columns: table => new
                {
                    FeedFileChangesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedFileChangesName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedFileChanges", x => x.FeedFileChangesId);
                });

            migrationBuilder.CreateTable(
                name: "FeedStatus",
                columns: table => new
                {
                    FeedStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedStatus", x => x.FeedStatusId);
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

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_FeedFileChangesId",
                table: "Feeds",
                column: "FeedFileChangesId");

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_FeedStatusId",
                table: "Feeds",
                column: "FeedStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_TargetFileTypeId",
                table: "Feeds",
                column: "TargetFileTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_FeedFileChanges_FeedFileChangesId",
                table: "Feeds",
                column: "FeedFileChangesId",
                principalTable: "FeedFileChanges",
                principalColumn: "FeedFileChangesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_FeedStatus_FeedStatusId",
                table: "Feeds",
                column: "FeedStatusId",
                principalTable: "FeedStatus",
                principalColumn: "FeedStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_FileTypes_TargetFileTypeId",
                table: "Feeds",
                column: "TargetFileTypeId",
                principalTable: "FileTypes",
                principalColumn: "FileTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_FileTypes_FileTypeId",
                table: "Files",
                column: "FileTypeId",
                principalTable: "FileTypes",
                principalColumn: "FileTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
