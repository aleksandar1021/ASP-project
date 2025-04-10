using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UseCaseLogsTableAndConfiguration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_useCaseLogs",
                table: "useCaseLogs");

            migrationBuilder.RenameTable(
                name: "useCaseLogs",
                newName: "UseCaseLogs");

            migrationBuilder.RenameIndex(
                name: "IX_useCaseLogs_Username_UseCaseName",
                table: "UseCaseLogs",
                newName: "IX_UseCaseLogs_Username_UseCaseName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UseCaseLogs",
                table: "UseCaseLogs",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UseCaseLogs",
                table: "UseCaseLogs");

            migrationBuilder.RenameTable(
                name: "UseCaseLogs",
                newName: "useCaseLogs");

            migrationBuilder.RenameIndex(
                name: "IX_UseCaseLogs_Username_UseCaseName",
                table: "useCaseLogs",
                newName: "IX_useCaseLogs_Username_UseCaseName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_useCaseLogs",
                table: "useCaseLogs",
                column: "Id");
        }
    }
}
