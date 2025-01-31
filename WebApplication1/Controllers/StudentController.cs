using Data;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private UniversityContext _context;
        public StudentController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Students.ToList());
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
                // data validated

                this._context.Add(student);
                return RedirectToAction("Index");
            }
            else
            {
                return View(); // go back to the form with errors
            }
        }
    }
}
