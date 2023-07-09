using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mailer.Migrations
{
    /// <inheritdoc />
    public partial class Create_Relation_Message_To_Request : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "Request",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_MessageId",
                table: "Request",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Message_MessageId",
                table: "Request",
                column: "MessageId",
                principalTable: "Message",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Message_MessageId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_MessageId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Request");
        }
    }
}
