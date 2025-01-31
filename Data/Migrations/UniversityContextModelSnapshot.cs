﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(UniversityContext))]
    partial class UniversityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("Data.Entities.EnrollmentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CourseEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Grade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CourseEntityId");

                    b.HasIndex("StudentID");

                    b.ToTable("enrollment");
                });

            modelBuilder.Entity("Data.Entity.CourseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Credits")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("InstructorEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InstructorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InstructorEntityId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Credits = 10,
                            InstructorId = 1,
                            Name = "ASP.NET",
                            Title = "SomeTitle"
                        });
                });

            modelBuilder.Entity("Data.Entity.InstructorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AcademicTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Instructors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AcademicTitle = "mgr inż.",
                            Name = "Konrad Ogłaza"
                        });
                });

            modelBuilder.Entity("StudentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("TEXT")
                        .HasColumnName("birth_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("IndexNumber")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("TEXT")
                        .HasColumnName("index");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("student");
                });

            modelBuilder.Entity("Data.Entities.EnrollmentEntity", b =>
                {
                    b.HasOne("Data.Entity.CourseEntity", null)
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseEntityId");

                    b.HasOne("StudentEntity", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Data.Entity.CourseEntity", b =>
                {
                    b.HasOne("Data.Entity.InstructorEntity", null)
                        .WithMany("Courses")
                        .HasForeignKey("InstructorEntityId");
                });

            modelBuilder.Entity("Data.Entity.CourseEntity", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("Data.Entity.InstructorEntity", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("StudentEntity", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
