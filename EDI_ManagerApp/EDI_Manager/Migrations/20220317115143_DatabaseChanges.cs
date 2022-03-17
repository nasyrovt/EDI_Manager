using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDI_Manager.Migrations
{
    public partial class DatabaseChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetEmails",
                table: "Feeds");

            migrationBuilder.AddColumn<int>(
                name: "BusinessDayOfMonth",
                table: "Feeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarrierId",
                table: "Feeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FeedSecurityType",
                table: "Feeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FeedStatus",
                table: "Feeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "Feeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FrequencyTimes",
                table: "Feeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PGPPassword",
                table: "Feeds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WeeklyRecurDay",
                table: "Feeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ZipPassword",
                table: "Feeds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CarrierType",
                columns: table => new
                {
                    CarrierTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrierType", x => x.CarrierTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Carrier",
                columns: table => new
                {
                    CarrierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarrierTypeId = table.Column<int>(type: "int", nullable: false),
                    CarrierTaxId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    SubGroupId = table.Column<int>(type: "int", nullable: true),
                    MasterPolicyNumber = table.Column<int>(type: "int", nullable: false),
                    Adress1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phones = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrier", x => x.CarrierId);
                    table.ForeignKey(
                        name: "FK_Carrier_CarrierType_CarrierTypeId",
                        column: x => x.CarrierTypeId,
                        principalTable: "CarrierType",
                        principalColumn: "CarrierTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_CarrierId",
                table: "Feeds",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrier_CarrierTypeId",
                table: "Carrier",
                column: "CarrierTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_Carrier_CarrierId",
                table: "Feeds",
                column: "CarrierId",
                principalTable: "Carrier",
                principalColumn: "CarrierId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_Carrier_CarrierId",
                table: "Feeds");

            migrationBuilder.DropTable(
                name: "Carrier");

            migrationBuilder.DropTable(
                name: "CarrierType");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_CarrierId",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "BusinessDayOfMonth",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "CarrierId",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "FeedSecurityType",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "FeedStatus",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "FrequencyTimes",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "PGPPassword",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "WeeklyRecurDay",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "ZipPassword",
                table: "Feeds");

            migrationBuilder.AddColumn<string>(
                name: "TargetEmails",
                table: "Feeds",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
