using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
        }

        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<EnrollmentEntity> Enrollments { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<InstructorEntity> Instructors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var path = System.IO.Path.Join(Environment.CurrentDirectory, "university.db");
            options.UseSqlite($"Data Source={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstructorEntity>().HasData(
                new InstructorEntity() { Id = 1, Name = "Konrad Ogłaza", AcademicTitle = "mgr inż." }
            );
            modelBuilder.Entity<CourseEntity>().HasData(
                new CourseEntity() { Id = 1, Name = "ASP.NET", Credits = 10, InstructorId = 1 }
            );
        }
    }
}