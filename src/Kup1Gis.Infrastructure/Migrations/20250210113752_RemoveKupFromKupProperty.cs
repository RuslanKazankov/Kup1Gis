using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kup1Gis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveKupFromKupProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KupProperties_Kups_KupId",
                table: "KupProperties");

            migrationBuilder.DropIndex(
                name: "IX_KupProperties_KupId",
                table: "KupProperties");

            migrationBuilder.DropColumn(
                name: "KupId",
                table: "KupProperties");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "KupId",
                table: "KupProperties",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_KupProperties_KupId",
                table: "KupProperties",
                column: "KupId");

            migrationBuilder.AddForeignKey(
                name: "FK_KupProperties_Kups_KupId",
                table: "KupProperties",
                column: "KupId",
                principalTable: "Kups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
