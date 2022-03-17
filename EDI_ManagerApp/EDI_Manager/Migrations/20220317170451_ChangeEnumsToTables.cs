using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDI_Manager.Migrations
{
    public partial class ChangeEnumsToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Frequency",
                table: "Feeds",
                newName: "FeedStatusId");

            migrationBuilder.RenameColumn(
                name: "FeedStatus",
                table: "Feeds",
                newName: "FeedSecurityTypeId");

            migrationBuilder.RenameColumn(
                name: "FeedSecurityType",
                table: "Feeds",
                newName: "FeedFrequencyId");

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
                name: "FeedFrequency",
                columns: table => new
                {
                    FeedFrequencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedFrequencyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedFrequency", x => x.FeedFrequencyId);
                });

            migrationBuilder.CreateTable(
                name: "FeedSecurityType",
                columns: table => new
                {
                    FeedSecurityTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedSecurityTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedSecurityType", x => x.FeedSecurityTypeId);
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

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_FeedFrequencyId",
                table: "Feeds",
                column: "FeedFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_FeedSecurityTypeId",
                table: "Feeds",
                column: "FeedSecurityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_FeedStatusId",
                table: "Feeds",
                column: "FeedStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_FeedFrequency_FeedFrequencyId",
                table: "Feeds",
                column: "FeedFrequencyId",
                principalTable: "FeedFrequency",
                principalColumn: "FeedFrequencyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_FeedSecurityType_FeedSecurityTypeId",
                table: "Feeds",
                column: "FeedSecurityTypeId",
                principalTable: "FeedSecurityType",
                principalColumn: "FeedSecurityTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_FeedStatus_FeedStatusId",
                table: "Feeds",
                column: "FeedStatusId",
                principalTable: "FeedStatus",
                principalColumn: "FeedStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_FeedFrequency_FeedFrequencyId",
                table: "Feeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_FeedSecurityType_FeedSecurityTypeId",
                table: "Feeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_FeedStatus_FeedStatusId",
                table: "Feeds");

            migrationBuilder.DropTable(
                name: "FeedFileChanges");

            migrationBuilder.DropTable(
                name: "FeedFrequency");

            migrationBuilder.DropTable(
                name: "FeedSecurityType");

            migrationBuilder.DropTable(
                name: "FeedStatus");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_FeedFrequencyId",
                table: "Feeds");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_FeedSecurityTypeId",
                table: "Feeds");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_FeedStatusId",
                table: "Feeds");

            migrationBuilder.RenameColumn(
                name: "FeedStatusId",
                table: "Feeds",
                newName: "Frequency");

            migrationBuilder.RenameColumn(
                name: "FeedSecurityTypeId",
                table: "Feeds",
                newName: "FeedStatus");

            migrationBuilder.RenameColumn(
                name: "FeedFrequencyId",
                table: "Feeds",
                newName: "FeedSecurityType");
        }
    }
}
