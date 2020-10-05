using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniLMS.Models
{
    public class Section
    {
        public int SectionId { get; set; }

        public string Semester { get; set; }

        public string SectionLetter { get; set; }

        public string InstructorName { get; set; }

        public int MaxStudents { get; set; }

        public DateTime StartDate { get; set; }

        // one to many link to Course  (Navigation Property)
        public Course Course { get; set; }
    }
}
