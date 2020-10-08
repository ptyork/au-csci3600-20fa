using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniLMS.Models
{
    public class Course
    {
        // POCO : Plain 'ol CLR Object (C# Object)

        public int CourseId { get; set; }

        [MaxLength(4)]
        [MinLength(2)]
        [Required]
        public string Prefix { get; set; }

        [Range(0, 9999)]
        [Required]
        public int Number { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        // one to many link to Section
        public List<Section> Sections { get; set; } = new List<Section>();

    }
}
