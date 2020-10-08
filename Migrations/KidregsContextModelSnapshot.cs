﻿// <auto-generated />
using System;
using Kidregs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kidregs.Migrations
{
    [DbContext(typeof(KidregsContext))]
    partial class KidregsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kidregs.Models.KidsInfo", b =>
                {
                    b.Property<DateTime?>("Birth")
                        .HasColumnName("birth")
                        .HasColumnType("date");

                    b.Property<string>("FatherName")
                        .HasColumnName("father_name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool?>("Gender")
                        .HasColumnName("gender")
                        .HasColumnType("bit");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IdCard")
                        .HasColumnName("IdCard")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("MotherName")
                        .HasColumnName("mother_name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Others")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("KidsInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
