using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testing_easy_db.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_allbanks",
                table: "allbanks");

            migrationBuilder.RenameTable(
                name: "allbanks",
                newName: "banks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_banks",
                table: "banks",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_banks",
                table: "banks");

            migrationBuilder.RenameTable(
                name: "banks",
                newName: "allbanks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_allbanks",
                table: "allbanks",
                column: "Id");
        }
    }
}
