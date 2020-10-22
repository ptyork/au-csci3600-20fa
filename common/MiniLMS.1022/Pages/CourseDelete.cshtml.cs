using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniLMS.Data;
using MiniLMS.Models;

namespace MiniLMS.Pages
{
    public class CourseDeleteModel : PageModel
    {
        private readonly MiniLMS.Data.MiniLMSDbContext _context;

        public CourseDeleteModel(MiniLMS.Data.MiniLMSDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Courses.FirstOrDefaultAsync(m => m.CourseId == id);

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Course == null || Course.CourseId == 0)
            {
                return NotFound();
            }

            //Course = await _context.Courses.FindAsync(Course.CourseId);

            _context.Remove(Course);
            await _context.SaveChangesAsync();

            //if (Course != null)
            //{
            //    _context.Courses.Remove(Course);
            //    await _context.SaveChangesAsync();
            //}

            return RedirectToPage("./Index");
        }
    }
}
