using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_relation_comment_notification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentID",
                table: "Notifications",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CommentID",
                table: "Notifications",
                column: "CommentID",
                unique: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Comments_CommentID",
                table: "Notifications",
                column: "CommentID",
                principalTable: "Comments",
                principalColumn: "CommentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Comments_CommentID",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_CommentID",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "CommentID",
                table: "Notifications");
        }
    }
}
