using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiniLMS.Models
{
    public class Student
    {
        //
        // DATA PROPERTIES
        //

        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public string CurrentMajor { get; set; }

        public string CurrentMinor { get; set; }

        public DateTime? GraduationDate { get; set; }

        public StudentCategory Category { get; set; }

        public StudentStates Status { get; set; }


        //
        // NAVIGATION PROPERTIES
        //

        // one to many relationship with Enrollments
        public List<Enrollment> Enrollments { get; set; }


        //
        // OTHER PROPERTIES AND METHODS
        //

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [NotMapped]
        public bool HasGraduated
        {
            get
            {
                return GraduationDate != null;
            }
        }

        [NotMapped]
        public bool IsActive
        {
            get
            {
                return !HasGraduated &&
                       Status <= StudentStates.AcademicProbation;
            }
        }

        //
        // Enumerated values (these are stored in the Database as ints
        //

        public enum StudentCategory
        {
            Undergraduate = 0,
            Graduate = 1
        }

        public enum StudentStates
        {
            GoodStanding = 0,
            AcademicProbation = 1,
            Inactive = 9
        }

    }
}
