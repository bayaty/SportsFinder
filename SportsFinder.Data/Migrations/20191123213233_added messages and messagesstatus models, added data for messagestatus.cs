using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsFinder.Data.Migrations
{
    public partial class addedmessagesandmessagesstatusmodelsaddeddataformessagestatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageStatus",
                columns: table => new
                {
                    MessageStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MessageStatusDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageStatus", x => x.MessageStatusId);
                });

            migrationBuilder.InsertData(
                table: "MessageStatus",
                columns: new[] { "MessageStatusId", "MessageStatusDescription" },
                values: new object[,]
                {
                    { 1, "Sent" },
                    { 2, "Received" },
                    { 3, "Deleted" },
                    { 4, "Delivered" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageStatus");
        }
    }
}
