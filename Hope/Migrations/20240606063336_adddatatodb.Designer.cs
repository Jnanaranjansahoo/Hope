﻿// <auto-generated />
using Hope.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hope.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240606063336_adddatatodb")]
    partial class adddatatodb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hope.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Photos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "3"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "5"
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
