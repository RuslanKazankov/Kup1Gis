using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kup1Gis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyInKup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordinates_Kups_KupId",
                table: "Coordinates");

            migrationBuilder.DropIndex(
                name: "IX_Coordinates_KupId",
                table: "Coordinates");

            migrationBuilder.CreateIndex(
                name: "IX_Kups_CoordinatesId",
                table: "Kups",
                column: "CoordinatesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kups_Coordinates_CoordinatesId",
                table: "Kups",
                column: "CoordinatesId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kups_Coordinates_CoordinatesId",
                table: "Kups");

            migrationBuilder.DropIndex(
                name: "IX_Kups_CoordinatesId",
                table: "Kups");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinates_KupId",
                table: "Coordinates",
                column: "KupId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinates_Kups_KupId",
                table: "Coordinates",
                column: "KupId",
                principalTable: "Kups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
