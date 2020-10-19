using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniLMS.Data;
using MiniLMS.Models;

namespace MiniLMS.Pages
{
    public class AssignInstructorModel : PageModel
    {
        MiniLMSDbContext _ctx = null;

        public Section Section { get; set; }
        public List<Instructor> Instructors { get; set; }

        public AssignInstructorModel(MiniLMSDbContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Section = _ctx.Sections
                .Include(s => s.Course)
                .Include(s => s.Instructor)
                .FirstOrDefault(s => s.SectionId == id);

            if (Section == null)
            {
                return NotFound();
            }

            this.Instructors = _ctx.Instructors.ToList();

            return Page();
        }

        public IActionResult OnPost()
        {
            var SectionId = HttpContext.Request.Form["SectionId"][0];
            var InstructorId = HttpContext.Request.Form["InstructorId"][0];

            var Section = _ctx.Sections.Find(int.Parse(SectionId));

            if (InstructorId == "0")
            {
                Section.InstructorId = null;
            }
            else
            {
                Section.InstructorId = int.Parse(InstructorId);
            }

            _ctx.SaveChanges();

            return Redirect("./SectionDetails?id=" + SectionId);
        }

    }

}
