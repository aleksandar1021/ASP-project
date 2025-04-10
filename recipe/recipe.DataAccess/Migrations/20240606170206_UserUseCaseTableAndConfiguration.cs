using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserUseCaseTableAndConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UseCaseLogs_Username_UseCaseName",
                table: "UseCaseLogs");

            migrationBuilder.CreateTable(
                name: "UserUseCases",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UseCaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUseCases", x => new { x.UserId, x.UseCaseId });
                    table.ForeignKey(
                        name: "FK_UserUseCases_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UseCaseLogs_Username_UseCaseName_ExecutedAt",
                table: "UseCaseLogs",
                columns: new[] { "Username", "UseCaseName", "ExecutedAt" })
                .Annotation("SqlServer:Include", new[] { "UseCaseData" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserUseCases");

            migrationBuilder.DropIndex(
                name: "IX_UseCaseLogs_Username_UseCaseName_ExecutedAt",
                table: "UseCaseLogs");

            migrationBuilder.CreateIndex(
                name: "IX_UseCaseLogs_Username_UseCaseName",
                table: "UseCaseLogs",
                columns: new[] { "Username", "UseCaseName" });
        }
    }
}
