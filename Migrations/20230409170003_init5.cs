using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoogleFormDeserializer.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QuizSettings_settingsId",
                table: "QuizSettings");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSettings_settingsId",
                table: "QuizSettings",
                column: "settingsId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QuizSettings_settingsId",
                table: "QuizSettings");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSettings_settingsId",
                table: "QuizSettings",
                column: "settingsId");
        }
    }
}
