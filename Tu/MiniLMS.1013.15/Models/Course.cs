using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiniLMS.Models
{
    public class Course
    {
        // POCO : Plain 'ol CLR Object (C# Object)

        //
        // DATA PROPERTIES
        //

        [Key]
        public int CourseId { get; set; }

        [MinLength(2)]
        [MaxLength(4)]
        [Required]
        [DisplayName("Pref")]
        public string Prefix { get; set; }

        [Range(0, 9999)]
        [Required]
        [DisplayName("Num")]
        public int Number { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }


        //
        // NAVIGATION PROPERTIES
        //

        // one to many relationship to Sections
        public List<Section> Sections { get; set; } = new List<Section>();

    }
}
