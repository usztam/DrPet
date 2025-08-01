﻿// <auto-generated />
using System;
using DrPet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DrPet.Data.Migrations
{
    [DbContext(typeof(VetDbContext))]
    partial class VetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DrPet.Data.Entities.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("DrPet.Data.Entities.DoctorDuty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("DoctorDuties");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Medication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Ownership", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "AnimalId");

                    b.HasIndex("AnimalId");

                    b.ToTable("Ownerships");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Treatments");
                });

            modelBuilder.Entity("DrPet.Data.Entities.TreatmentEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HistoryEntryId")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("Length")
                        .HasColumnType("time");

                    b.Property<int?>("MedicationId")
                        .HasColumnType("int");

                    b.Property<int>("TreatmentId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HistoryEntryId");

                    b.HasIndex("MedicationId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("TreatmentEntries");
                });

            modelBuilder.Entity("DrPet.Data.Entities.DoctorDuty", b =>
                {
                    b.HasOne("DrPet.Data.Entities.Employee", "Employee")
                        .WithMany("DoctorDuties")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Ownership", b =>
                {
                    b.HasOne("DrPet.Data.Entities.Animal", "Animal")
                        .WithMany("Ownerships")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrPet.Data.Entities.Person", "Person")
                        .WithMany("Ownerships")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Treatment", b =>
                {
                    b.HasOne("DrPet.Data.Entities.Animal", "Animal")
                        .WithMany("Treatments")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrPet.Data.Entities.Employee", "Doctor")
                        .WithMany("Treatments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DrPet.Data.Entities.Person", "Owner")
                        .WithMany("Treatments")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Doctor");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("DrPet.Data.Entities.TreatmentEntry", b =>
                {
                    b.HasOne("DrPet.Data.Entities.TreatmentEntry", "HistoryEntry")
                        .WithMany()
                        .HasForeignKey("HistoryEntryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DrPet.Data.Entities.Medication", "Medication")
                        .WithMany("TreatmentEntries")
                        .HasForeignKey("MedicationId");

                    b.HasOne("DrPet.Data.Entities.Treatment", "Treatment")
                        .WithMany("Entries")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HistoryEntry");

                    b.Navigation("Medication");

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Animal", b =>
                {
                    b.Navigation("Ownerships");

                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Employee", b =>
                {
                    b.Navigation("DoctorDuties");

                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Medication", b =>
                {
                    b.Navigation("TreatmentEntries");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Person", b =>
                {
                    b.Navigation("Ownerships");

                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("DrPet.Data.Entities.Treatment", b =>
                {
                    b.Navigation("Entries");
                });
#pragma warning restore 612, 618
        }
    }
}
