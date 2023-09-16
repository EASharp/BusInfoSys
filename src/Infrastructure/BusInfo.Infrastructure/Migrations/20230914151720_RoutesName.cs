using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusInfo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RoutesName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Route");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Route",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Route");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Route",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
