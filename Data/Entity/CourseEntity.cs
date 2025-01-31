using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Entity
{
    public class CourseEntity
    {
        [Key]  // Oznaczenie, że to jest klucz główny
        public int Id { get; set; }

        [Required]  // Właściwość wymagana (nie może być null)
        public string Title { get; set; }

        [Required]  // Właściwość wymagana (nie może być null)
        public int Credits { get; set; }

        [Required]  // Właściwość wymagana (nie może być null)
        public int InstructorId { get; set; }  // Id wykładowcy przypisanego do kursu

        [Required]  // Właściwość wymagana (nie może być null)
        public String Name { get; set; }

        public ICollection<EnrollmentEntity> Enrollments { get; set; }
    }
}
