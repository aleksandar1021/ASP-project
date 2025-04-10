using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FollowEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Follows_FollowId",
                table: "Follows",
                column: "FollowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Users_FollowId",
                table: "Follows",
                column: "FollowId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Users_FollowId",
                table: "Follows");

            migrationBuilder.DropIndex(
                name: "IX_Follows_FollowId",
                table: "Follows");
        }
    }
}
