﻿// <auto-generated />
using CodeFirstPractice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeFirstPractice.Migrations
{
    [DbContext(typeof(ShelvesContext))]
    partial class ShelvesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CodeFirstPractice.Models.ShelfMaterials", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(10)");

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasColumnName("materialname")
                        .HasColumnType("varchar(25)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("ID");

                    b.ToTable("ShelfMaterial");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            MaterialName = "metal"
                        },
                        new
                        {
                            ID = 2,
                            MaterialName = "wire"
                        },
                        new
                        {
                            ID = 3,
                            MaterialName = "wood"
                        },
                        new
                        {
                            ID = 4,
                            MaterialName = "plastic"
                        },
                        new
                        {
                            ID = 5,
                            MaterialName = "concrete"
                        });
                });

            modelBuilder.Entity("CodeFirstPractice.Models.Shelves", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<int>("ShelfMaterialID")
                        .HasColumnName("shelfMaterial_id")
                        .HasColumnType("int(10)");

                    b.HasKey("ID");

                    b.HasIndex("ShelfMaterialID")
                        .HasName("FK_Shelves_ShelfMaterials");

                    b.ToTable("Shelves");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Movies Shelf",
                            ShelfMaterialID = 1
                        },
                        new
                        {
                            ID = 2,
                            Name = "Books Shelf",
                            ShelfMaterialID = 1
                        },
                        new
                        {
                            ID = 3,
                            Name = "Cloths Shelf",
                            ShelfMaterialID = 1
                        },
                        new
                        {
                            ID = 4,
                            Name = "Tools Shelf",
                            ShelfMaterialID = 1
                        },
                        new
                        {
                            ID = 5,
                            Name = "Games Shelf",
                            ShelfMaterialID = 1
                        });
                });

            modelBuilder.Entity("CodeFirstPractice.Models.Shelves", b =>
                {
                    b.HasOne("CodeFirstPractice.Models.ShelfMaterials", "ShelfMaterials")
                        .WithMany("Shelves")
                        .HasForeignKey("ShelfMaterialID")
                        .HasConstraintName("FK_Shelves_ShelfMaterials")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
