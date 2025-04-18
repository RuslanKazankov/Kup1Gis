using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.Entity.KupEntity;
using Kup1Gis.Domain.Entity.KupEntity.ObservationEntity;
using Kup1Gis.Domain.Entity.KupEntity.ObservationEntity.KupPropertyEntity;
using Microsoft.EntityFrameworkCore;

namespace Kup1Gis.Infrastructure.Persistence;

public sealed class AppDbContext : DbContext
{
    private static readonly IEnumerable<string> BasicProperties =
    [
        "Породы",
        "Возраст",
        "Свита/подсвита/ярус",
        "Индекс",
        "Залегание пород аз.пад.,\u00b0",
        "Залегание пород уг.пад.,\u00b0",
        "Основные системы аз.пад.,\u00b0",
        "Основные системы уг.пад.,\u00b0",
        "Основные системы Sк, м",
        "Основные системы Sср, м",
        "Основные системы Sм, м",
        "Основные системы V, м3",
        "Vg, м3",
        "Основные максимумы с диаграмм трещиноватости (3 или более в случае равной интенсивности I)  аз.пад.,\u00b0",
        "Основные максимумы с диаграмм трещиноватости (3 или более в случае равной интенсивности I)  уг.пад.,\u00b0",
        "Основные максимумы с диаграмм трещиноватости (3 или более в случае равной интенсивности I)  I",
        "Сколы со штрихами аз.пад.,\u00b0",
        "Сколы со штрихами уг.пад.,\u00b0",
        "Штрихи аз.скл.,\u00b0",
        "Штрихи уг.пад.,\u00b0",
        "Штрихи Тип подвижки",
        "Сколы со смещениями аз.пад.,\u00b0",
        "Сколы со смещениями уг.пад.,\u00b0",
        "Сколы со смещениями Амплитуда смещения, м",
        "Сколы со смещениями Тип подвижки",
        "Шарнир складки/длиная ось будины аз.пад.,\u00b0",
        "Шарнир складки/длиная ось будины уг.скл.,\u00b0",
        "Зоны разрывных нарушений тип",
        "Зоны разрывных нарушений аз. пад., \u00b0",
        "Зоны разрывных нарушений уг. пад., \u00b0",
        "Зоны разрывных нарушений мощность, м",
        "Крупные сколы аз. пад.,\u00b0",
        "Крупные сколы уг. пад.",
        "Крупные сколы макс. зияние",
        "N, м2",
        "другие деформации",
        "Простирание тектонических долин/расщенин, \u00b0",
        "Другие наблюдения",
        "фото",
        "примечание"
    ];

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Kup> Kups { get; set; }
    public DbSet<Coordinates> Coordinates { get; set; }
    public DbSet<KupProperty> KupProperties { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<PropertyValue> PropertyValues { get; set; }
    public DbSet<KupImage> KupImages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Kup1Gis.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Kup>().HasAlternateKey(k => k.Name);
        modelBuilder.Entity<Property>().HasAlternateKey(p => p.Name);

        modelBuilder
            .Entity<Kup>()
            .HasOne(k => k.Coordinates)
            .WithOne(c => c.Kup)
            .HasForeignKey<Kup>(k => k.CoordinatesId);

        modelBuilder.Entity<Property>().HasData(
            BasicProperties.Select((property, i) =>
                new Property
                {
                    Id = i + 1,
                    Name = property
                })
        );
    }
}