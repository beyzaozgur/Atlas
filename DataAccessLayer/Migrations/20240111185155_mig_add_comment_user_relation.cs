using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_comment_user_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommenterID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommenterID",
                table: "Comments",
                column: "CommenterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CommenterID",
                table: "Comments",
                column: "CommenterID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CommenterID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommenterID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommenterID",
                table: "Comments");
        }
    }
}
