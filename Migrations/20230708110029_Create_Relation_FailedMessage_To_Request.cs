using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mailer.Migrations
{
    /// <inheritdoc />
    public partial class Create_Relation_FailedMessage_To_Request : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FailedMessageId",
                table: "Request",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_FailedMessageId",
                table: "Request",
                column: "FailedMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_FailedMessage_FailedMessageId",
                table: "Request",
                column: "FailedMessageId",
                principalTable: "FailedMessage",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_FailedMessage_FailedMessageId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_FailedMessageId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "FailedMessageId",
                table: "Request");
        }
    }
}
