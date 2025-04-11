using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kup1Gis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Latitude = table.Column<decimal>(type: "TEXT", nullable: false),
                    Longitude = table.Column<decimal>(type: "TEXT", nullable: false),
                    AbsMarkOfSea = table.Column<double>(type: "REAL", nullable: true),
                    Eksp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
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
                    table.ForeignKey(
                        name: "FK_Kups_Coordinates_CoordinatesId",
                        column: x => x.CoordinatesId,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "KupProperties",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropertyId = table.Column<long>(type: "INTEGER", nullable: false),
                    KupId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KupProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KupProperties_Kups_KupId",
                        column: x => x.KupId,
                        principalTable: "Kups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KupProperties_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KupPropertyId = table.Column<long>(type: "INTEGER", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyValues_KupProperties_KupPropertyId",
                        column: x => x.KupPropertyId,
                        principalTable: "KupProperties",
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
                    { 9L, "Основные системы Sк, м" },
                    { 10L, "Основные системы Sср, м" },
                    { 11L, "Основные системы Sм, м" },
                    { 12L, "Основные системы V, м3" },
                    { 13L, "Vg, м3" },
                    { 14L, "Основные максимумы с диаграмм трещиноватости (3 или более в случае равной интенсивности I)  аз.пад.,°" },
                    { 15L, "Основные максимумы с диаграмм трещиноватости (3 или более в случае равной интенсивности I)  уг.пад.,°" },
                    { 16L, "Основные максимумы с диаграмм трещиноватости (3 или более в случае равной интенсивности I)  I" },
                    { 17L, "Сколы со штрихами аз.пад.,°" },
                    { 18L, "Сколы со штрихами уг.пад.,°" },
                    { 19L, "Штрихи аз.скл.,°" },
                    { 20L, "Штрихи уг.пад.,°" },
                    { 21L, "Штрихи Тип подвижки" },
                    { 22L, "Сколы со смещениями аз.пад.,°" },
                    { 23L, "Сколы со смещениями уг.пад.,°" },
                    { 24L, "Сколы со смещениями Амплитуда смещения, м" },
                    { 25L, "Сколы со смещениями Тип подвижки" },
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
                name: "IX_KupImages_KupId",
                table: "KupImages",
                column: "KupId");

            migrationBuilder.CreateIndex(
                name: "IX_KupProperties_KupId",
                table: "KupProperties",
                column: "KupId");

            migrationBuilder.CreateIndex(
                name: "IX_KupProperties_PropertyId",
                table: "KupProperties",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Kups_CoordinatesId",
                table: "Kups",
                column: "CoordinatesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyValues_KupPropertyId",
                table: "PropertyValues",
                column: "KupPropertyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KupImages");

            migrationBuilder.DropTable(
                name: "PropertyValues");

            migrationBuilder.DropTable(
                name: "KupProperties");

            migrationBuilder.DropTable(
                name: "Kups");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Coordinates");
        }
    }
}
