using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mailer.Migrations
{
    /// <inheritdoc />
    public partial class Create_Relation_Sender_To_Request : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Request",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_SenderId",
                table: "Request",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Sender_SenderId",
                table: "Request",
                column: "SenderId",
                principalTable: "Sender",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Sender_SenderId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_SenderId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Request");
        }
    }
}
