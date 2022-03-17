using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDI_Manager.Migrations
{
    public partial class DatabaseChangesDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrier_CarrierType_CarrierTypeId",
                table: "Carrier");

            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_Carrier_CarrierId",
                table: "Feeds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrierType",
                table: "CarrierType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carrier",
                table: "Carrier");

            migrationBuilder.RenameTable(
                name: "CarrierType",
                newName: "CarrierTypes");

            migrationBuilder.RenameTable(
                name: "Carrier",
                newName: "Carriers");

            migrationBuilder.RenameIndex(
                name: "IX_Carrier_CarrierTypeId",
                table: "Carriers",
                newName: "IX_Carriers_CarrierTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrierTypes",
                table: "CarrierTypes",
                column: "CarrierTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carriers",
                table: "Carriers",
                column: "CarrierId");

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    PlatformId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.PlatformId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Carriers_CarrierTypes_CarrierTypeId",
                table: "Carriers",
                column: "CarrierTypeId",
                principalTable: "CarrierTypes",
                principalColumn: "CarrierTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_Carriers_CarrierId",
                table: "Feeds",
                column: "CarrierId",
                principalTable: "Carriers",
                principalColumn: "CarrierId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carriers_CarrierTypes_CarrierTypeId",
                table: "Carriers");

            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_Carriers_CarrierId",
                table: "Feeds");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrierTypes",
                table: "CarrierTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carriers",
                table: "Carriers");

            migrationBuilder.RenameTable(
                name: "CarrierTypes",
                newName: "CarrierType");

            migrationBuilder.RenameTable(
                name: "Carriers",
                newName: "Carrier");

            migrationBuilder.RenameIndex(
                name: "IX_Carriers_CarrierTypeId",
                table: "Carrier",
                newName: "IX_Carrier_CarrierTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrierType",
                table: "CarrierType",
                column: "CarrierTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carrier",
                table: "Carrier",
                column: "CarrierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrier_CarrierType_CarrierTypeId",
                table: "Carrier",
                column: "CarrierTypeId",
                principalTable: "CarrierType",
                principalColumn: "CarrierTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_Carrier_CarrierId",
                table: "Feeds",
                column: "CarrierId",
                principalTable: "Carrier",
                principalColumn: "CarrierId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
