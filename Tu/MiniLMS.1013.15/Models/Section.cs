using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MiniLMS.Models
{
    public class Section
    {
        //
        // DATA PROPERTIES
        //

        [Key]
        public int SectionId { get; set; }

        [Required]
        [MaxLength(4)]
        public string Semester { get; set; }

        [Required,MaxLength(1)] // NO!!!!
        public string SectionLetter { get; set; }

        [Range(0,999)]
        public int? MaxStudents { get; set; } = 30;

        // Good idea to have "flags" here to avoid the need to actually delete
        // data from the database. This is especially bad with so many other
        // tables related to this one since it would require a LOT of cascading.
        public bool IsActive { get; set; } = false;

        public DateTime? StartDate { get; set; }


        //
        // NAVIGATION PROPERTIES
        //

        // Many to one relationship to Instructors
        public Instructor Instructor { get; set; }
        // Just because let's specify the FK Field
        // Also because it's "best practice"
        // Oh, also because we want it nullable
        public int? InstructorId { get; set; }

        // many to one relationship to Courses
        public Course Course { get; set; }
        // still sepcifying the FK field, but NOT nullable because it's required
        public int CourseId { get; set; }

        // one to many relationship to Enrollments
        public List<Enrollment> Enrollments { get; set; }

    }
}
