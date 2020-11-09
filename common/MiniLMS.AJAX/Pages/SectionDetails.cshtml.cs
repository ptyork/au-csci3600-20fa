using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MiniLMS.Data;
using MiniLMS.Models;

namespace MiniLMS.Pages
{
    public class SectionDetailsModel : PageModel
    {
        readonly MiniLMSDbContext _ctx = null;
        readonly ILogger _log = null;

        //[BindProperty(SupportsGet = true)]
        //public int? Id { get; set; }

        public Section Section { get; set; }

        public SectionDetailsModel(MiniLMSDbContext ctx, ILogger<SectionDetailsModel> logger)
        {
            _ctx = ctx;
            _log = logger;
        }

        public IActionResult OnGet(int? id)
        //public IActionResult OnGet()
        {
            _log.LogInformation($"Getting Section {id}");

            if (id == null)
            {
                _log.LogWarning($"Section {id} not found");
                return NotFound();
            }

            Section = _ctx.Sections
                .Include(s => s.Course)
                .Include(s => s.Instructor)
                .FirstOrDefault(s => s.SectionId == id);
                // .Find(id);

            if (Section == null)
            {
                _log.LogWarning($"Section {id} not found in database");
                return NotFound();
            }

            return Page();
        }
    }
}
