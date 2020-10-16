using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniLMS.Data;
using MiniLMS.Models;

namespace MiniLMS.Pages.Admin.Sections
{
    public class CreateModel : PageModel
    {
        private readonly MiniLMS.Data.MiniLMSDbContext _context;

        public CreateModel(MiniLMS.Data.MiniLMSDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Prefix");
        ViewData["InstructorId"] = new SelectList(_context.Instructors, "InstructorId", "FirstName");
            return Page();
        }

        [BindProperty]
        public Section Section { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sections.Add(Section);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
