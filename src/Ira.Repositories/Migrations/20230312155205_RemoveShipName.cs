using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ira.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class RemoveShipName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ship");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ship",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
