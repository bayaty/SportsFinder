using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsFinder.Data.Migrations
{
    public partial class AddedtheDbSetsnecessaryformessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageStatus",
                table: "MessageStatus");

            migrationBuilder.RenameTable(
                name: "MessageStatus",
                newName: "MessageStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageStatuses",
                table: "MessageStatuses",
                column: "MessageStatusId");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MessageFromId = table.Column<string>(nullable: true),
                    MessageToId = table.Column<string>(nullable: true),
                    MessageContent = table.Column<string>(nullable: true),
                    MessageStatusId = table.Column<int>(nullable: false),
                    DateSent = table.Column<DateTime>(nullable: false),
                    DateReceived = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_MessageFromId",
                        column: x => x.MessageFromId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_MessageStatuses_MessageStatusId",
                        column: x => x.MessageStatusId,
                        principalTable: "MessageStatuses",
                        principalColumn: "MessageStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_MessageToId",
                        column: x => x.MessageToId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageFromId",
                table: "Messages",
                column: "MessageFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageStatusId",
                table: "Messages",
                column: "MessageStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageToId",
                table: "Messages",
                column: "MessageToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageStatuses",
                table: "MessageStatuses");

            migrationBuilder.RenameTable(
                name: "MessageStatuses",
                newName: "MessageStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageStatus",
                table: "MessageStatus",
                column: "MessageStatusId");
        }
    }
}
