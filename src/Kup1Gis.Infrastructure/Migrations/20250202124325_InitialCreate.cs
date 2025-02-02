using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kup1Gis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    GeographicalReference = table.Column<string>(type: "TEXT", nullable: false),
                    CoordinatesId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kups", x => x.Id);
                    table.UniqueConstraint("AK_Kups_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.UniqueConstraint("AK_Properties_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Latitude = table.Column<decimal>(type: "TEXT", nullable: false),
                    Longitude = table.Column<decimal>(type: "TEXT", nullable: false),
                    AbsMarkOfSea = table.Column<double>(type: "REAL", nullable: true),
                    Eksp = table.Column<string>(type: "TEXT", nullable: false),
                    KupId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coordinates_Kups_KupId",
                        column: x => x.KupId,
                        principalTable: "Kups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Observations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KupId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Observations_Kups_KupId",
                        column: x => x.KupId,
                        principalTable: "Kups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KupProperties",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KupId = table.Column<long>(type: "INTEGER", nullable: false),
                    PropertyId = table.Column<long>(type: "INTEGER", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    ObservationId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KupProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KupProperties_Kups_KupId",
                        column: x => x.KupId,
                        principalTable: "Kups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KupProperties_Observations_ObservationId",
                        column: x => x.ObservationId,
                        principalTable: "Observations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KupProperties_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Породы" },
                    { 2L, "Возраст" },
                    { 3L, "Свита/подсвита/ярус" },
                    { 4L, "Индекс" },
                    { 5L, "Залегание пород аз.пад.,°" },
                    { 6L, "Залегание пород уг.пад.,°" },
                    { 7L, "Основные системы аз.пад.,°" },
                    { 8L, "Основные системы уг.пад.,°" },
                    { 9L, "Sк, м" },
                    { 10L, "Sср, м" },
                    { 11L, "Sм, м" },
                    { 12L, "V, м3" },
                    { 13L, "Vg, м3" },
                    { 14L, "Основные максимумы с диаграмм трещиноватости (3 или более в случае равной интенсивности I)  аз.пад.,°" },
                    { 15L, "Основные максимумы с диаграмм трещиноватости (3 или более в случае равной интенсивности I)  уг.пад.,°" },
                    { 16L, "Основные максимумы с диаграмм трещиноватости (3 или более в случае равной интенсивности I)  I" },
                    { 17L, "Сколы со штрихами аз.пад.,°" },
                    { 18L, "Сколы со штрихами уг.пад.,°" },
                    { 19L, "Штрихи аз.скл.,°" },
                    { 20L, "Штрихи уг.пад.,°" },
                    { 21L, "Тип подвижки" },
                    { 22L, "Сколы со смещениями аз.пад.,°" },
                    { 23L, "Сколы со смещениями уг.пад.,°" },
                    { 24L, "Амплитуда смещения, м" },
                    { 25L, "Тип подвижки" },
                    { 26L, "Шарнир складки/длиная ось будины аз.пад.,°" },
                    { 27L, "Шарнир складки/длиная ось будины уг.скл.,°" },
                    { 28L, "Зоны разрывных нарушений тип" },
                    { 29L, "Зоны разрывных нарушений аз. пад., °" },
                    { 30L, "Зоны разрывных нарушений уг. пад., °" },
                    { 31L, "Зоны разрывных нарушений мощность, м" },
                    { 32L, "Крупные сколы аз. пад.,°" },
                    { 33L, "Крупные сколы уг. пад." },
                    { 34L, "Крупные сколы макс. зияние" },
                    { 35L, "N, м2" },
                    { 36L, "другие деформации" },
                    { 37L, "Простирание тектонических долин/расщенин, °" },
                    { 38L, "Другие наблюдения" },
                    { 39L, "фото" },
                    { 40L, "примечание" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coordinates_KupId",
                table: "Coordinates",
                column: "KupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KupProperties_KupId",
                table: "KupProperties",
                column: "KupId");

            migrationBuilder.CreateIndex(
                name: "IX_KupProperties_ObservationId",
                table: "KupProperties",
                column: "ObservationId");

            migrationBuilder.CreateIndex(
                name: "IX_KupProperties_PropertyId",
                table: "KupProperties",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_KupId",
                table: "Observations",
                column: "KupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropTable(
                name: "KupProperties");

            migrationBuilder.DropTable(
                name: "Observations");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Kups");
        }
    }
}
