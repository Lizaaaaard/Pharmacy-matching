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
    [Migration("20230323161846_AddNewElement")]
    partial class AddNewElement
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                            Description = "It is most commonly used as a pain killer, or to reduce fever or inflammation. It also has an anti-platelet effect - it reduces the number of platelets in the blood which reduces blood clotting- in that function it is used to prevent heart attacks.",
                            IsPrescription = false,
                            Name = "Aspirin",
                            ProducerCompanyName = "Zeba",
                            ProducerCountry = "Germany"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Pharmacological group of the substance Iodine:macro- and microelements, antiseptics and disinfectants, local irritating agents in combinations, other hypolipidemic agents",
                            IsPrescription = false,
                            Name = "Iodine",
                            ProducerCompanyName = "Beba",
                            ProducerCountry = "Belarus"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Ibuprofen has a rapid analgesic, antipyretic and anti-inflammatory effect. In addition, ibuprofen reversibly inhibits platelet aggregation.",
                            IsPrescription = false,
                            Name = "ibuprofen",
                            ProducerCompanyName = "Maxima",
                            ProducerCountry = "Germany"
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

            modelBuilder.Entity("Domain.Entities.Dose", b =>
                {
                    b.Navigation("MedcToPharms");
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