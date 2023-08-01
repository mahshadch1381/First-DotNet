using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testing_easy_db.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SuperHeroes",
                table: "SuperHeroes");

            migrationBuilder.RenameTable(
                name: "SuperHeroes",
                newName: "allbanks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_allbanks",
                table: "allbanks",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_allbanks",
                table: "allbanks");

            migrationBuilder.RenameTable(
                name: "allbanks",
                newName: "SuperHeroes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuperHeroes",
                table: "SuperHeroes",
                column: "Id");
        }
    }
}
