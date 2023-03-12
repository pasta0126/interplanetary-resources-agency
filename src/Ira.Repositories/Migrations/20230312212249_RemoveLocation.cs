using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ira.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "A",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "CA",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "HwA",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "OA",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "QwA",
                table: "Location");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "A",
                table: "Location",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CA",
                table: "Location",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HwA",
                table: "Location",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OA",
                table: "Location",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QwA",
                table: "Location",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }
    }
}
