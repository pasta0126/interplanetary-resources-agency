using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ira.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddingLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Route");

            migrationBuilder.AddColumn<Guid>(
                name: "DestinationId",
                table: "Route",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OriginId",
                table: "Route",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SentDate",
                table: "Notification",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cluster = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Nebula = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Galaxy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Planet = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    A = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HwA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QwA = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Route_DestinationId",
                table: "Route",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_OriginId",
                table: "Route",
                column: "OriginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Route_Location_DestinationId",
                table: "Route",
                column: "DestinationId",
                principalTable: "Location",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Route_Location_OriginId",
                table: "Route",
                column: "OriginId",
                principalTable: "Location",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Route_Location_DestinationId",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_Location_OriginId",
                table: "Route");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Route_DestinationId",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Route_OriginId",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "Route");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Route",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Route",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SentDate",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
