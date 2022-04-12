using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDI_Manager.Migrations
{
    public partial class GroupSubGroupPolicyNumberDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Carriers");

            migrationBuilder.DropColumn(
                name: "MasterPolicyNumber",
                table: "Carriers");

            migrationBuilder.DropColumn(
                name: "SubGroupId",
                table: "Carriers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Carriers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MasterPolicyNumber",
                table: "Carriers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubGroupId",
                table: "Carriers",
                type: "int",
                nullable: true);
        }
    }
}
