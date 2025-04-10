using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SetIndexesOnTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_Username_Email",
                table: "Users",
                columns: new[] { "Username", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RatingValue",
                table: "Ratings",
                column: "RatingValue",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Username_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_RatingValue",
                table: "Ratings");
        }
    }
}
