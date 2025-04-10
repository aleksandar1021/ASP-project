using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "RecipeRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRatings_UserId",
                table: "RecipeRatings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRatings_Users_UserId",
                table: "RecipeRatings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRatings_Users_UserId",
                table: "RecipeRatings");

            migrationBuilder.DropIndex(
                name: "IX_RecipeRatings_UserId",
                table: "RecipeRatings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RecipeRatings");
        }
    }
}
