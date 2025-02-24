﻿// <auto-generated />
using Kup1Gis.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kup1Gis.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250211114741_FixForeignKeyInKup")]
    partial class FixForeignKeyInKup
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("Kup1Gis.Domain.Entity.Coordinates", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("AbsMarkOfSea")
                        .HasColumnType("REAL");

                    b.Property<string>("Eksp")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("KupId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("Kup1Gis.Domain.Entity.Kup", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<long>("CoordinatesId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GeographicalReference")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("CoordinatesId")
                        .IsUnique();

                    b.ToTable("Kups");
                });

            modelBuilder.Entity("Kup1Gis.Domain.Entity.KupProperty", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ObservationId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("PropertyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ObservationId");

                    b.HasIndex("PropertyId");

                    b.ToTable("KupProperties");
                });

            modelBuilder.Entity("Kup1Gis.Domain.Entity.Observation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("KupId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("KupId");

                    b.ToTable("Observations");
                });

            modelBuilder.Entity("Kup1Gis.Domain.Entity.Property", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Properties");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Породы"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Возраст"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Свита/подсвита/ярус"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Индекс"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Залегание пород аз.пад.,°"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Залегание пород уг.пад.,°"
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Основные системы аз.пад.,°"
                        },
                        new
                        {
                            Id = 8L,
                            Name = "Основные системы уг.пад.,°"
                        },
                        new
                        {
                            Id = 9L,
                            Name = "Sк, м"
                        },
                        new
                        {
                            Id = 10L,
                            Name = "Sср, м"
                        },
                        new
                        {
                            Id = 11L,
                            Name = "Sм, м"
                        },
                        new
                        {
                            Id = 12L,
                            Name = "V, м3"
                        },
                        new
                        {
                            Id = 13L,
                            Name = "Vg, м3"
                        },
                        new
                        {
                            Id = 14L,
                            Name = "Основные максимумы с диаграмм трещиноватости (3 или более в случае равной интенсивности I)  аз.пад.,°"
                        },
                        new
                        {
                            Id = 15L,
                            Name = "Основные максимумы с диаграмм трещиноватости (3 или более в случае равной интенсивности I)  уг.пад.,°"
                        },
                        new
                        {
                            Id = 16L,
                            Name = "Основные максимумы с диаграмм трещиноватости (3 или более в случае равной интенсивности I)  I"
                        },
                        new
                        {
                            Id = 17L,
                            Name = "Сколы со штрихами аз.пад.,°"
                        },
                        new
                        {
                            Id = 18L,
                            Name = "Сколы со штрихами уг.пад.,°"
                        },
                        new
                        {
                            Id = 19L,
                            Name = "Штрихи аз.скл.,°"
                        },
                        new
                        {
                            Id = 20L,
                            Name = "Штрихи уг.пад.,°"
                        },
                        new
                        {
                            Id = 21L,
                            Name = "Тип подвижки"
                        },
                        new
                        {
                            Id = 22L,
                            Name = "Сколы со смещениями аз.пад.,°"
                        },
                        new
                        {
                            Id = 23L,
                            Name = "Сколы со смещениями уг.пад.,°"
                        },
                        new
                        {
                            Id = 24L,
                            Name = "Амплитуда смещения, м"
                        },
                        new
                        {
                            Id = 25L,
                            Name = "Тип подвижки"
                        },
                        new
                        {
                            Id = 26L,
                            Name = "Шарнир складки/длиная ось будины аз.пад.,°"
                        },
                        new
                        {
                            Id = 27L,
                            Name = "Шарнир складки/длиная ось будины уг.скл.,°"
                        },
                        new
                        {
                            Id = 28L,
                            Name = "Зоны разрывных нарушений тип"
                        },
                        new
                        {
                            Id = 29L,
                            Name = "Зоны разрывных нарушений аз. пад., °"
                        },
                        new
                        {
                            Id = 30L,
                            Name = "Зоны разрывных нарушений уг. пад., °"
                        },
                        new
                        {
                            Id = 31L,
                            Name = "Зоны разрывных нарушений мощность, м"
                        },
                        new
                        {
                            Id = 32L,
                            Name = "Крупные сколы аз. пад.,°"
                        },
                        new
                        {
                            Id = 33L,
                            Name = "Крупные сколы уг. пад."
                        },
                        new
                        {
                            Id = 34L,
                            Name = "Крупные сколы макс. зияние"
                        },
                        new
                        {
                            Id = 35L,
                            Name = "N, м2"
                        },
                        new
                        {
                            Id = 36L,
                            Name = "другие деформации"
                        },
                        new
                        {
                            Id = 37L,
                            Name = "Простирание тектонических долин/расщенин, °"
                        },
                        new
                        {
                            Id = 38L,
                            Name = "Другие наблюдения"
                        },
                        new
                        {
                            Id = 39L,
                            Name = "фото"
                        },
                        new
                        {
                            Id = 40L,
                            Name = "примечание"
                        });
                });

            modelBuilder.Entity("Kup1Gis.Domain.Entity.Kup", b =>
                {
                    b.HasOne("Kup1Gis.Domain.Entity.Coordinates", "Coordinates")
                        .WithOne("Kup")
                        .HasForeignKey("Kup1Gis.Domain.Entity.Kup", "CoordinatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coordinates");
                });

            modelBuilder.Entity("Kup1Gis.Domain.Entity.KupProperty", b =>
                {
                    b.HasOne("Kup1Gis.Domain.Entity.Observation", null)
                        .WithMany("KupProperties")
                        .HasForeignKey("ObservationId");

                    b.HasOne("Kup1Gis.Domain.Entity.Property", "Property")
                        .WithMany("KupProperties")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Kup1Gis.Domain.Entity.Observation", b =>
                {
                    b.HasOne("Kup1Gis.Domain.Entity.Kup", "Kup")
                        .WithMany("Observations")
                        .HasForeignKey("KupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kup");
                });

            modelBuilder.Entity("Kup1Gis.Domain.Entity.Coordinates", b =>
                {
                    b.Navigation("Kup")
                        .IsRequired();
                });

            modelBuilder.Entity("Kup1Gis.Domain.Entity.Kup", b =>
                {
                    b.Navigation("Observations");
                });

            modelBuilder.Entity("Kup1Gis.Domain.Entity.Observation", b =>
                {
                    b.Navigation("KupProperties");
                });

            modelBuilder.Entity("Kup1Gis.Domain.Entity.Property", b =>
                {
                    b.Navigation("KupProperties");
                });
#pragma warning restore 612, 618
        }
    }
}
