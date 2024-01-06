using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class add_comment_blog_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogID",
                table: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Message_SenderID",
                table: "Messages",
                newName: "IX_Messages_SenderID");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ReceiverID",
                table: "Messages",
                newName: "IX_Messages_ReceiverID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogID",
                table: "Comments",
                column: "BlogID",
                principalTable: "Blogs",
                principalColumn: "BlogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Writers_ReceiverID",
                table: "Messages",
                column: "ReceiverID",
                principalTable: "Writers",
                principalColumn: "WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Writers_SenderID",
                table: "Messages",
                column: "SenderID",
                principalTable: "Writers",
                principalColumn: "WriterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Writers_ReceiverID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Writers_SenderID",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderID",
                table: "Message",
                newName: "IX_Message_SenderID");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ReceiverID",
                table: "Message",
                newName: "IX_Message_ReceiverID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "MessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogID",
                table: "Comments",
                column: "BlogID",
                principalTable: "Blogs",
                principalColumn: "BlogID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Writers_ReceiverID",
                table: "Message",
                column: "ReceiverID",
                principalTable: "Writers",
                principalColumn: "WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Writers_SenderID",
                table: "Message",
                column: "SenderID",
                principalTable: "Writers",
                principalColumn: "WriterID");
        }
    }
}
