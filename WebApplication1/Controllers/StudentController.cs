using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        static List<StudentViewModel> students = new List<StudentViewModel>();

        [HttpGet]
        public IActionResult Index(string searchTerm)
        {
            var filteredStudents = string.IsNullOrWhiteSpace(searchTerm)
                ? students
                : students.Where(s => s.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

            return View(filteredStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                student.Id = (students.Count > 0 ? students.Max(x => x.Id) : 0) + 1;
                students.Add(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(StudentViewModel updatedStudent)
        {
            if (ModelState.IsValid)
            {
                var student = students.FirstOrDefault(x => x.Id == updatedStudent.Id);
                if (student != null)
                {
                    student.Name = updatedStudent.Name;
                    student.Email = updatedStudent.Email;
                    student.IndexNumber = updatedStudent.IndexNumber;
                    student.Birth = updatedStudent.Birth;
                }
                return RedirectToAction("Index");
            }

            return View(updatedStudent);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                students.Remove(student);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}

