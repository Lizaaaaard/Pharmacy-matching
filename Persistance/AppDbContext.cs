//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
//using PharmacyMatching.ViewModel;

namespace Persistance
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDto> UsersDto { get; set; }
        public DbSet<MedcToPharm> MedcToPharms { get; set; }
        public DbSet<Dose> Doses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
           // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
            modelBuilder.Entity<Dose>()
                .HasMany(m => m.MedcToPharms)
                .WithOne(d => d.Doses)
                .HasForeignKey(d => d.Id);
            modelBuilder.Entity<Dose>().HasData(
                new Dose
                {
                    Id = 1,
                    Package = "tablets 50mg in pack no.30",
                    Price = (decimal)8.25,
                    Amount = 4
                },
                new Dose
                {
                    Id = 2,
                    Package = "tablets 100mg in pack no.60",
                    Price = (decimal)13.99,
                    Amount = 2
                },
                new Dose
                {
                    Id = 3,
                    Package = "tablets 50mg in pack no.30",
                    Price = (decimal)8.25,
                    Amount = 11
                },
                new Dose
                {
                    Id = 4,
                    Package = "tablets 100mg in pack no.60",
                    Price = (decimal)14.14,
                    Amount = 8
                },
                new Dose
                {
                    Id = 5,
                    Package = "tablets 150mg in pack no.70",
                    Price = (decimal)4.99,
                    Amount = 1
                },
                new Dose
                {
                    Id = 6,
                    Package = "tablets 100mg in pack no.60",
                    Price = (decimal)7.00,
                    Amount = 0
                },
                new Dose
                {
                    Id = 7,
                    Package = "tablets 50mg in pack no.30",
                    Price = (decimal)10.33,
                    Amount = 5
                },
                new Dose
                {
                    Id = 8,
                    Package = "tablets 50mg in pack no.30",
                    Price = (decimal)1.50,
                    Amount = 0
                }
            );

            modelBuilder.Entity<Medicine>().HasData(
                new Medicine
                {
                    Id = 1,
                    Name = "Aspirin",
                    Description =
                        "It is most commonly used as a pain killer, or to reduce fever or inflammation. It also has an anti-platelet effect - it reduces the number of platelets in the blood which reduces blood clotting- in that function it is used to prevent heart attacks.",
                    IsPrescription = false,
                    ProducerCountry = "Germany",
                    ProducerCompanyName = "Zeba",
                    ReleaseForm = "tablets"
                },
                new Medicine
                {
                    Id = 2,
                    Name = "Iodine",
                    Description =
                        "Pharmacological group of the substance Iodine:macro- and microelements, antiseptics and disinfectants, local irritating agents in combinations, other hypolipidemic agents",
                    IsPrescription = false,
                    ProducerCountry = "Belarus",
                    ProducerCompanyName = "Beba",
                    ReleaseForm = "tablets"
                },
                new Medicine
                {
                    Id = 3,
                    Name = "ibuprofen",
                    Description =
                        "Ibuprofen has a rapid analgesic, antipyretic and anti-inflammatory effect. In addition, ibuprofen reversibly inhibits platelet aggregation.",
                    IsPrescription = false,
                    ProducerCountry = "Germany",
                    ProducerCompanyName = "Maxima",
                    ReleaseForm = "capsules"
                }
            );
            modelBuilder.Entity<MedcToPharm>().HasData(
                new MedcToPharm
                {
                    Id = 1,
                    PharmId = 1,
                    MedcId = 1,
                    DoseId = 1
                },
                new MedcToPharm
                {
                    Id = 2,
                    PharmId = 1,
                    MedcId = 1,
                    DoseId = 3
                },
                new MedcToPharm
                {
                    Id = 3,
                    PharmId = 2,
                    MedcId = 1,
                    DoseId = 1
                },
                new MedcToPharm
                {
                    Id = 4,
                    PharmId = 2,
                    MedcId = 3,
                    DoseId = 3
                },
                new MedcToPharm
                {
                    Id = 5,
                    PharmId = 2,
                    MedcId = 2,
                    DoseId = 1
                },
                new MedcToPharm
                {
                    Id = 6,
                    PharmId = 3,
                    MedcId = 3,
                    DoseId = 1
                },
                new MedcToPharm
                {
                    Id = 7,
                    PharmId = 3,
                    MedcId = 2,
                    DoseId = 1
                }
            );
        }
    
}
}
