using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mailer.Migrations
{
    /// <inheritdoc />
    public partial class Create_Relation_Result_To_Request : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "Request",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_ResultId",
                table: "Request",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Result_ResultId",
                table: "Request",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Result_ResultId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_ResultId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Request");
        }
    }
}
