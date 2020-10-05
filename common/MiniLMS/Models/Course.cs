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

        public string Prefix { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // one to many link to Section
        public List<Section> Sections { get; set; } = new List<Section>();

    }
}
