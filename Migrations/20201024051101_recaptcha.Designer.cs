﻿// <auto-generated />
using System;
using Kidregs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kidregs.Migrations
{
    [DbContext(typeof(KidregsContext))]
    [Migration("20201024051101_recaptcha")]
    partial class recaptcha
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kidregs.Models.KidsInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Accommodating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrushTeeth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Case")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DadIdCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DadName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DadPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DadWorkRes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Defecate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fever")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GetUpTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("GrandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GrandPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GrandWorkRes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hobbies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeAddres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IndieEat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("KidBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("KidDomicile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KidGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KidHouseholdType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KidIdCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KidName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KidNation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KidRegRes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LikeAsk")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LikeFood")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LikePlay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LikeRead")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MealLength")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MunIdCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MunName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MunPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MunWorkRes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nap")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Others")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SensibiligenFood")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SensibiligenMedicine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SleepTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Urinate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WashHand")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KidsInfo");
                });

            modelBuilder.Entity("Kidregs.Models.NationList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NationList");
                });

            modelBuilder.Entity("Kidregs.Models.System", b =>
                {
                    b.Property<string>("CopyrightMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RegSwitch")
                        .HasColumnType("bit");

                    b.Property<string>("SiteName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WelcomeMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("reCAPTCHASwitch")
                        .HasColumnType("bit");

                    b.Property<string>("reCAPTCHA_AppId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reCAPTCHA_Secret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reCAPTCHA_ServerUrl")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("System");
                });
#pragma warning restore 612, 618
        }
    }
}
