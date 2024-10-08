﻿using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedcToPharm> MedcToPharms { get; set; }
        public DbSet<Dose> Doses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pharmacy>()
                .HasMany(m => m.Medicines)
                .WithMany(p => p.Pharmacies)
                .UsingEntity<MedcToPharm>(
                    j => j
                        .HasOne(pt => pt.Medicine)
                        .WithMany(t => t.MedcToPharms)
                        .HasForeignKey(pt => pt.MedcId),
                    j => j
                        .HasOne(pt => pt.Pharmacy)
                        .WithMany(t => t.MedcToPharms)
                        .HasForeignKey(pt => pt.PharmId),
                    j =>
                    {
                        j.HasKey(t => new { t.PharmId, t.MedcId });
                        j.ToTable("MedcToPharm");
                    }
                )
                .HasData(
                    new Pharmacy
                    {
                        Id = 1,
                        Name = "Pharmacy №1",
                        Description = "Working hours: 7:00 - 22:00, no lunches, no days off",
                        Address = "35, Sherwood street",
                        PhoneNumber = "1234567890128"
                    },
                    new Pharmacy
                    {
                        Id = 2,
                        Name = "Adele",
                        Description = "Working hours: 00 - 24",
                        Address = "167, Gray-Village avenue",
                        PhoneNumber = "1233367890128"
                    },
                    new Pharmacy
                    {
                        Id = 3,
                        Name = "Pharmacy №16",
                        Description = "Working hours: 8:30 - 23:00, lunch break: 13:00 - 13:45",
                        Address = "45, Andreas street",
                        PhoneNumber = "1234567896668"
                    }
                );
            modelBuilder.Entity<MedcToPharm>().HasKey(m => m.Id);
            modelBuilder.Entity<MedcToPharm>()
                .HasOne(m => m.Doses)
                .WithMany(d => d.MedcToPharms)
                .HasForeignKey(d => d.DoseId);
            modelBuilder.Entity<Dose>().HasData(
                new Dose
                {
                    Id = 1,
                    Package = "tablets 50mg in pack no.40",
                    ReleaseForm = "tablets"
                },
                new Dose
                {
                    Id = 2,
                    Package = "syrop 1000ml in pack",
                    ReleaseForm = "syrop"
                },
                new Dose
                {
                    Id = 3,
                    Package = "capsules 50mg in pack no.25",
                    ReleaseForm = "capsules"
                },
                new Dose
                {
                    Id = 4,
                    Package = "tablets 100mg in pack no.60",
                    ReleaseForm = "tablets"
                },
                new Dose
                {
                    Id = 5,
                    Package = "capsules 150mg in pack no.70",
                    ReleaseForm = "capsules"
                },
                new Dose
                {
                    Id = 6,
                    Package = "tablets 100mg in pack no.40",
                    ReleaseForm = "tablets"
                },
                new Dose
                {
                    Id = 7,
                    Package = "tablets 50mg in pack no.35",
                    ReleaseForm = "tablets"
                },
                new Dose
                {
                    Id = 8,
                    Package = "tablets 50mg in pack no.30",
                    ReleaseForm = "tablets"
                }
            );

            modelBuilder.Entity<Medicine>().HasData(
                new Medicine
                {
                    Id = 1,
                    Name = "Aspirin",
                    Description = "It is most commonly used as a pain killer, or to reduce fever or inflammation.",
                    IsPrescription = false,
                    ProducerCountry = "Germany",
                    ProducerCompanyName = "Zeba"
                },
                new Medicine
                {
                    Id = 2,
                    Name = "Iodine",
                    Description = "Pharmacological group of the substance Iodine: antiseptics and disinfectants, local irritating agents",
                    IsPrescription = false,
                    ProducerCountry = "Belarus",
                    ProducerCompanyName = "Beba"
                },
                new Medicine
                {
                    Id = 3,
                    Name = "ibuprofen",
                    Description = "Ibuprofen has a rapid analgesic, antipyretic and anti-inflammatory effect.",
                    IsPrescription = false,
                    ProducerCountry = "Germany",
                    ProducerCompanyName = "Maxima"
                }
            );
            modelBuilder.Entity<MedcToPharm>().HasData(
                new MedcToPharm
                {
                    Id = 1,
                    PharmId = 1,
                    MedcId = 1,
                    DoseId = 1,
                    Price = (decimal)3.90,
                    Amount = 17
                },
                new MedcToPharm
                {
                    Id = 2,
                    PharmId = 1,
                    MedcId = 1,
                    DoseId = 3,
                    Price = (decimal)10.33,
                    Amount = 2
                },
                new MedcToPharm
                {
                    Id = 3,
                    PharmId = 2,
                    MedcId = 1,
                    DoseId = 1,
                    Price = (decimal)10.33,
                    Amount = 4
                },
                new MedcToPharm
                {
                    Id = 4,
                    PharmId = 2,
                    MedcId = 3,
                    DoseId = 3,
                    Price = (decimal)12.50,
                    Amount = 11
                },
                new MedcToPharm
                {
                    Id = 5,
                    PharmId = 2,
                    MedcId = 2,
                    DoseId = 1,
                    Price = (decimal)4.99,
                    Amount = 1
                },
                new MedcToPharm
                {
                    Id = 6,
                    PharmId = 3,
                    MedcId = 3,
                    DoseId = 1,
                    Price = (decimal)10.00,
                    Amount = 2
                },
                new MedcToPharm
                {
                    Id = 7,
                    PharmId = 3,
                    MedcId = 2,
                    DoseId = 1,
                    Price = (decimal)7.30,
                    Amount = 6
                },
                new MedcToPharm
                {
                    Id = 8,
                    PharmId = 1,
                    MedcId = 2,
                    DoseId = 1,
                    Price = (decimal)10.00,
                    Amount = 0
                }
            );
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Order>()
                .HasOne(m => m.MedcToPharm)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.MedcToPharmId);
            modelBuilder.Entity<Booking>().HasKey(b => b.Id);
            modelBuilder.Entity<Order>()
                .HasOne(c => c.Booking)
                .WithMany(o => o.Orders)
                .HasForeignKey(b => b.BookingId);


            modelBuilder.Entity<UserRole>(p =>
            {
                p.Property(u => u.AssignDate).IsRequired();
                p.Property(u => u.PharmId).IsRequired(false);
            });

            //modelBuilder.Entity<Pharmacy>()
            //    .HasMany(p => p.UserRoles)
            //    .WithOne(u => u.Pharmacy)
            //    .HasForeignKey(u => u.PharmId);

            modelBuilder.Entity<UserRole>()
                .HasOne(p => p.Pharmacy)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(u => u.PharmId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

        }

    }
}
