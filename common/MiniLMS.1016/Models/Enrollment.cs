using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiniLMS.Models
{
    public class Enrollment
    {
        //
        // DATA PROPERTIES
        //

        [Key]
        public int EnrollmentId { get; set; }

        public DateTime? WithdrawalDate { get; set; }

        [Range(0, 110)]
        public float? NumericalGrade { get; set; }

        [MaxLength(2)]
        public string LetterGrade { get; set; }


        //
        // NAVIGATION PROPERTIES
        //

        // many to one relationship with Sections
        public int SectionId { get; set; }
        public Section Section { get; set; }

        // many to one relationship with Students
        public int StudentId { get; set; }
        public Student Student { get; set; }

        //
        // OTHER PROPERTIES AND METHODS
        //
        [NotMapped]
        public bool IsEnrolled
        {
            get
            {
                return WithdrawalDate == null;
            }
        }
    }
}
