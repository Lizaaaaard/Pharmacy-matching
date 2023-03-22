﻿// <auto-generated />
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
    [Migration("20230304074726_UpdateMedcToPharmModel")]
    partial class UpdateMedcToPharmModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.MedcToPharm", b =>
                {
                    b.Property<int>("PharmId")
                        .HasColumnType("int");

                    b.Property<int>("MedcId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(5);

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PharmId", "MedcId");

                    b.HasIndex("MedcId");

                    b.ToTable("MedcToPharm", (string)null);

                    b.HasData(
                        new
                        {
                            PharmId = 1,
                            MedcId = 1,
                            Amount = 15,
                            Id = 1,
                            Price = 8.25m
                        },
                        new
                        {
                            PharmId = 1,
                            MedcId = 3,
                            Amount = 9,
                            Id = 2,
                            Price = 6.5m
                        },
                        new
                        {
                            PharmId = 2,
                            MedcId = 1,
                            Amount = 0,
                            Id = 3,
                            Price = 0m
                        },
                        new
                        {
                            PharmId = 2,
                            MedcId = 3,
                            Amount = 10,
                            Id = 4,
                            Price = 3.2m
                        },
                        new
                        {
                            PharmId = 3,
                            MedcId = 3,
                            Amount = 7,
                            Id = 5,
                            Price = 15.79m
                        },
                        new
                        {
                            PharmId = 3,
                            MedcId = 2,
                            Amount = 10,
                            Id = 6,
                            Price = 10.99m
                        });
                });

            modelBuilder.Entity("Domain.Entities.Medicines", b =>
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

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReleaseForm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medicines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "It is most commonly used as a pain killer, or to reduce fever or inflammation. It also has an anti-platelet effect - it reduces the number of platelets in the blood which reduces blood clotting- in that function it is used to prevent heart attacks.",
                            IsPrescription = false,
                            Name = "Aspirin",
                            Producer = "Germany",
                            ReleaseForm = "tablets"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Pharmacological group of the substance Iodine:macro- and microelements, antiseptics and disinfectants, local irritating agents in combinations, other hypolipidemic agents",
                            IsPrescription = false,
                            Name = "Iodine",
                            Producer = "Belarus",
                            ReleaseForm = "tablets"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Ibuprofen has a rapid analgesic, antipyretic and anti-inflammatory effect. In addition, ibuprofen reversibly inhibits platelet aggregation.",
                            IsPrescription = false,
                            Name = "ibuprofen",
                            Producer = "Germany",
                            ReleaseForm = "capsules"
                        });
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

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.UserDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UsersDto");
                });

            modelBuilder.Entity("Domain.Entities.MedcToPharm", b =>
                {
                    b.HasOne("Domain.Entities.Medicines", "Medicines")
                        .WithMany("MedcToPharms")
                        .HasForeignKey("MedcId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Pharmacy", "Pharmacy")
                        .WithMany("MedcToPharms")
                        .HasForeignKey("PharmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicines");

                    b.Navigation("Pharmacy");
                });

            modelBuilder.Entity("Domain.Entities.Medicines", b =>
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
