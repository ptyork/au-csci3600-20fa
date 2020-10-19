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
    public class SectionDetailsModel : PageModel
    {
        MiniLMSDbContext _ctx = null;

        public Section Section { get; set; }

        public SectionDetailsModel(MiniLMSDbContext ctx)
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
                // .Find(id);

            if (Section == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
