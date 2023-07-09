using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mailer.Migrations
{
    /// <inheritdoc />
    public partial class Create_Relation_Recipient_To_Request : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipientId",
                table: "Request",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_RecipientId",
                table: "Request",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Recipient_RecipientId",
                table: "Request",
                column: "RecipientId",
                principalTable: "Recipient",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Recipient_RecipientId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_RecipientId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "Request");
        }
    }
}
