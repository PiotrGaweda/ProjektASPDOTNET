using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class InstructorEntity
    {
        [Key]  // Oznaczenie, że to jest klucz główny
        public int Id { get; set; }

        [Required]  // Właściwość wymagana (nie może być null)
        [StringLength(100)]  // Ograniczenie długości nazwy wykładowcy
        public string Name { get; set; }

        [StringLength(50)]  // Ograniczenie długości tytułu naukowego
        public string AcademicTitle { get; set; }  // Tytuł naukowy wykładowcy

        public ICollection<CourseEntity> Courses { get; set; }
    }
}
