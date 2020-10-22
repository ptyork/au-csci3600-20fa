using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniLMS.Data;
using MiniLMS.Models;

namespace MiniLMS.Pages.Admin.Sections
{
    public class DeleteModel : PageModel
    {
        private readonly MiniLMS.Data.MiniLMSDbContext _context;

        public DeleteModel(MiniLMS.Data.MiniLMSDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Section Section { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Section = await _context.Sections
                .Include(s => s.Course)
                .Include(s => s.Instructor).FirstOrDefaultAsync(m => m.SectionId == id);

            if (Section == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Section = await _context.Sections.FindAsync(id);

            if (Section != null)
            {
                _context.Sections.Remove(Section);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
