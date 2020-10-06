using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniLMS.Models
{
    public class Section
    {
        public int SectionId { get; set; }

        [Required]
        [MaxLength(4)]
        public string Semester { get; set; }

        [Required]
        [MaxLength(1)]
        public string SectionLetter { get; set; }


        // OPTIONAL RELATIONSHIP
        public int? InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public int? MaxStudents { get; set; }

        public DateTime? StartDate { get; set; }

        // one to many link to Course  (Navigation Property)
        // REQUIRED RELATIONSHIP
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
