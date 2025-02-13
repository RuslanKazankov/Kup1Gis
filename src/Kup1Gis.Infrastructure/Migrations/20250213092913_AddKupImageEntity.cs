using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kup1Gis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddKupImageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KupImages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    KupId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KupImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KupImages_Kups_KupId",
                        column: x => x.KupId,
                        principalTable: "Kups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KupImages_KupId",
                table: "KupImages",
                column: "KupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KupImages");
        }
    }
}
