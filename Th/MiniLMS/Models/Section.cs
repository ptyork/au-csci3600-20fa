using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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

        [Required,MaxLength(1)] // NO!!!!
        public string SectionLetter { get; set; }

        //public string InstructorName { get; set; }
        public Instructor Instructor { get; set; }
        // Just b/c let's specify the FK Field
        // Oh, also b/c we want it nullable
        public int? InstructorId { get; set; }

        [Range(0,999)]
        public int? MaxStudents { get; set; } = 30;

        public bool IsActive { get; set; } = false;

        public DateTime? StartDate { get; set; }

        // one to many link to Course  (Navigation Property)
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
