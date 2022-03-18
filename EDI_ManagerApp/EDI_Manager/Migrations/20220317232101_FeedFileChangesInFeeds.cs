using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDI_Manager.Migrations
{
    public partial class FeedFileChangesInFeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeedFileChangesId",
                table: "Feeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_FeedFileChangesId",
                table: "Feeds",
                column: "FeedFileChangesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_FeedFileChanges_FeedFileChangesId",
                table: "Feeds",
                column: "FeedFileChangesId",
                principalTable: "FeedFileChanges",
                principalColumn: "FeedFileChangesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_FeedFileChanges_FeedFileChangesId",
                table: "Feeds");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_FeedFileChangesId",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "FeedFileChangesId",
                table: "Feeds");
        }
    }
}
