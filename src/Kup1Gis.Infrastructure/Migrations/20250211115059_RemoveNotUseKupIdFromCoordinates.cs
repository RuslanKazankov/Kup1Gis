using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kup1Gis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNotUseKupIdFromCoordinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KupId",
                table: "Coordinates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "KupId",
                table: "Coordinates",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
