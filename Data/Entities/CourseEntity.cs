using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("course")]
    public class CourseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Credits { get; set; }

        [Required]
        [Column("instructor_id")]
        public int InstructorId { get; set; }

        public ICollection<EnrollmentEntity> Enrollments { get; set; }
    }
}
