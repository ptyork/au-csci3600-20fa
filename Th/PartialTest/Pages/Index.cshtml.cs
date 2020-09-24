using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PartialTest.Models;

namespace PartialTest.Pages
{
    public class IndexModel : PageModel
    {
        public List<Student> Students { get; set; } = new List<Student>();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            //Students = new List<Student>();
        }

        public void OnGet()
        {
            // NORMALLY you'd get this from a database
            Student stu = new Student();
            stu.ID = 1;
            stu.FirstName = "Stuart";
            stu.LastName = "TheMouse";
            stu.Grade = 12.7;
            Students.Add(
                stu
            );

            var stu2 = new Student() {
                ID=2,
                FirstName="Bubba",
                LastName="Smith",
                Grade=17.7
            };
            Students.Add(stu2);

            Students.Add(new Student {
                ID=3,
                FirstName="Paul",
                LastName="York",
                Grade=100.0
            });
        }
    }
}
