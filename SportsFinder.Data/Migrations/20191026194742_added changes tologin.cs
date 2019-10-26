using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsFinder.Data.Migrations
{
    public partial class addedchangestologin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Gender_GenderId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Gender_GenderId",
                table: "AspNetUsers",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Gender_GenderId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Gender_GenderId",
                table: "AspNetUsers",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
