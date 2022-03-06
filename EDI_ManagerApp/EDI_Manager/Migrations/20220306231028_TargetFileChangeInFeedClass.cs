using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDI_Manager.Migrations
{
    public partial class TargetFileChangeInFeedClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_Files_TargetFileId",
                table: "Feeds");

            migrationBuilder.RenameColumn(
                name: "TargetFileId",
                table: "Feeds",
                newName: "TargetFileTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Feeds_TargetFileId",
                table: "Feeds",
                newName: "IX_Feeds_TargetFileTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_FileTypes_TargetFileTypeId",
                table: "Feeds",
                column: "TargetFileTypeId",
                principalTable: "FileTypes",
                principalColumn: "FileTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_FileTypes_TargetFileTypeId",
                table: "Feeds");

            migrationBuilder.RenameColumn(
                name: "TargetFileTypeId",
                table: "Feeds",
                newName: "TargetFileId");

            migrationBuilder.RenameIndex(
                name: "IX_Feeds_TargetFileTypeId",
                table: "Feeds",
                newName: "IX_Feeds_TargetFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_Files_TargetFileId",
                table: "Feeds",
                column: "TargetFileId",
                principalTable: "Files",
                principalColumn: "FileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
