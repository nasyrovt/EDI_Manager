using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDI_Manager.Migrations
{
    public partial class ElectionsComplexKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Elections",
                table: "Elections");

            migrationBuilder.AlterColumn<string>(
                name: "SourceFilePath",
                table: "Elections",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Elections",
                table: "Elections",
                columns: new[] { "ElectionId", "SourceFilePath" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Elections",
                table: "Elections");

            migrationBuilder.AlterColumn<string>(
                name: "SourceFilePath",
                table: "Elections",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Elections",
                table: "Elections",
                column: "ElectionId");
        }
    }
}
