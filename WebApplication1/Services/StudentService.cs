using Data;
using Data.Entities;
using System;
using WebApplication1.Mappers;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class StudentService : IStudentService
    {
        private UniversityContext _context;

        public StudentService(UniversityContext context)
        {
            _context = context;
        }

        public int Add(StudentViewModel student)
        {
            var entity = _context.Students.Add(StudentMapper.ToEntity(student));
            _context.SaveChanges();
            return entity.Entity.Id;  // Zwraca ID dodanego studenta
        }

        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();  // Zapisz zmiany po usunięciu
            }
        }

        public List<StudentViewModel> FindAll()
        {
            return _context.Students
                .Select(e => StudentMapper.FromEntity(e))  // Mapowanie encji na widok
                .ToList();
        }

        public StudentViewModel? FindById(int id)
        {
            var student = _context.Students.Find(id);
            return student != null ? StudentMapper.FromEntity(student) : null;
        }

        public void Update(StudentViewModel student)
        {
            var entity = StudentMapper.ToEntity(student);
            _context.Students.Update(entity);
            _context.SaveChanges();  // Zapisz zmiany po aktualizacji
        }
    }
}

