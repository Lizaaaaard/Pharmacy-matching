﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance;

#nullable disable

namespace Persistance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230511131252_RefactoringBookingTables")]
    partial class RefactoringBookingTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Domain.Entities.Dose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Package")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReleaseForm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Package = "tablets 50mg in pack no.40",
                            ReleaseForm = "tablets"
                        },
                        new
                        {
                            Id = 2,
                            Package = "syrop 1000ml in pack",
                            ReleaseForm = "syrop"
                        },
                        new
                        {
                            Id = 3,
                            Package = "capsules 50mg in pack no.25",
                            ReleaseForm = "capsules"
                        },
                        new
                        {
                            Id = 4,
                            Package = "tablets 100mg in pack no.60",
                            ReleaseForm = "tablets"
                        },
                        new
                        {
                            Id = 5,
                            Package = "capsules 150mg in pack no.70",
                            ReleaseForm = "capsules"
                        },
                        new
                        {
                            Id = 6,
                            Package = "tablets 100mg in pack no.40",
                            ReleaseForm = "tablets"
                        },
                        new
                        {
                            Id = 7,
                            Package = "tablets 50mg in pack no.35",
                            ReleaseForm = "tablets"
                        },
                        new
                        {
                            Id = 8,
                            Package = "tablets 50mg in pack no.30",
                            ReleaseForm = "tablets"
                        });
                });

            modelBuilder.Entity("Domain.Entities.MedcToPharm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("DoseId")
                        .HasColumnType("int");

                    b.Property<int>("MedcId")
                        .HasColumnType("int");

                    b.Property<int>("PharmId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DoseId");

                    b.HasIndex("MedcId");

                    b.HasIndex("PharmId");

                    b.ToTable("MedcToPharm", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 17,
                            DoseId = 1,
                            MedcId = 1,
                            PharmId = 1,
                            Price = 3.9m
                        },
                        new
                        {
                            Id = 2,
                            Amount = 2,
                            DoseId = 3,
                            MedcId = 1,
                            PharmId = 1,
                            Price = 10.33m
                        },
                        new
                        {
                            Id = 3,
                            Amount = 4,
                            DoseId = 1,
                            MedcId = 1,
                            PharmId = 2,
                            Price = 10.33m
                        },
                        new
                        {
                            Id = 4,
                            Amount = 11,
                            DoseId = 3,
                            MedcId = 3,
                            PharmId = 2,
                            Price = 12.5m
                        },
                        new
                        {
                            Id = 5,
                            Amount = 1,
                            DoseId = 1,
                            MedcId = 2,
                            PharmId = 2,
                            Price = 4.99m
                        },
                        new
                        {
                            Id = 6,
                            Amount = 2,
                            DoseId = 1,
                            MedcId = 3,
                            PharmId = 3,
                            Price = 10m
                        },
                        new
                        {
                            Id = 7,
                            Amount = 6,
                            DoseId = 1,
                            MedcId = 2,
                            PharmId = 3,
                            Price = 7.3m
                        },
                        new
                        {
                            Id = 8,
                            Amount = 0,
                            DoseId = 1,
                            MedcId = 2,
                            PharmId = 1,
                            Price = 10m
                        });
                });

            modelBuilder.Entity("Domain.Entities.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPrescription")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProducerCompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProducerCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medicines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "It is most commonly used as a pain killer, or to reduce fever or inflammation.",
                            IsPrescription = false,
                            Name = "Aspirin",
                            ProducerCompanyName = "Zeba",
                            ProducerCountry = "Germany"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Pharmacological group of the substance Iodine: antiseptics and disinfectants, local irritating agents",
                            IsPrescription = false,
                            Name = "Iodine",
                            ProducerCompanyName = "Beba",
                            ProducerCountry = "Belarus"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Ibuprofen has a rapid analgesic, antipyretic and anti-inflammatory effect.",
                            IsPrescription = false,
                            Name = "ibuprofen",
                            ProducerCompanyName = "Maxima",
                            ProducerCountry = "Germany"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("MedcToPharmId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("MedcToPharmId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Entities.Pharmacy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pharmacies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "35, Sherwood street",
                            Description = "Working hours: 7:00 - 22:00, no lunches, no days off",
                            Name = "Pharmacy №1",
                            PhoneNumber = "1234567890128"
                        },
                        new
                        {
                            Id = 2,
                            Address = "167, Gray-Village avenue",
                            Description = "Working hours: 00 - 24",
                            Name = "Adele",
                            PhoneNumber = "1233367890128"
                        },
                        new
                        {
                            Id = 3,
                            Address = "45, Andreas street",
                            Description = "Working hours: 8:30 - 23:00, lunch break: 13:00 - 13:45",
                            Name = "Pharmacy №16",
                            PhoneNumber = "1234567896668"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MedcToPharm", b =>
                {
                    b.HasOne("Domain.Entities.Dose", "Doses")
                        .WithMany("MedcToPharms")
                        .HasForeignKey("DoseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Medicine", "Medicine")
                        .WithMany("MedcToPharms")
                        .HasForeignKey("MedcId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Pharmacy", "Pharmacy")
                        .WithMany("MedcToPharms")
                        .HasForeignKey("PharmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doses");

                    b.Navigation("Medicine");

                    b.Navigation("Pharmacy");
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.HasOne("Domain.Entities.Booking", "Booking")
                        .WithMany("Orders")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.MedcToPharm", "MedcToPharm")
                        .WithMany("Orders")
                        .HasForeignKey("MedcToPharmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("MedcToPharm");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Booking", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Domain.Entities.Dose", b =>
                {
                    b.Navigation("MedcToPharms");
                });

            modelBuilder.Entity("Domain.Entities.MedcToPharm", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Domain.Entities.Medicine", b =>
                {
                    b.Navigation("MedcToPharms");
                });

            modelBuilder.Entity("Domain.Entities.Pharmacy", b =>
                {
                    b.Navigation("MedcToPharms");
                });
#pragma warning restore 612, 618
        }
    }
}
