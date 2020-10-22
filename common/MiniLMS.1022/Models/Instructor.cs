using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiniLMS.Models
{
    public class Instructor
    {
        //
        // DATA PROPERTIES
        //

        [Key]
        public int InstructorId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime? TerminationDate { get; set; }


        //
        // NAVIGATION PROPERTIES
        //

        // one to many relationship with Sections
        public List<Section> Sections { get; set; }

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
        public bool IsActive
        {
            get
            {
                return TerminationDate != null;
            }
        }

    }
}
