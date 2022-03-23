using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDI_Manager.Migrations
{
    public partial class FeedRefactorings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BusinessDayOfMonth",
                table: "Feeds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "EndDate",
                table: "Feeds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Series",
                table: "Feeds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartDate",
                table: "Feeds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "Series",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Feeds");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessDayOfMonth",
                table: "Feeds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
