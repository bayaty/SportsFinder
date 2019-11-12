using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsFinder.Data.Migrations
{
    public partial class FixEventFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_CreatorId1",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_CreatorId1",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CreatorId1",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Events",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_CreatorId",
                table: "Events",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_CreatorId",
                table: "Events",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_CreatorId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_CreatorId",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Events",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorId1",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_CreatorId1",
                table: "Events",
                column: "CreatorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_CreatorId1",
                table: "Events",
                column: "CreatorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
