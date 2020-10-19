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
    public class StudentsModel : PageModel
    {
        private readonly MiniLMS.Data.MiniLMSDbContext _context;

        public StudentsModel(MiniLMS.Data.MiniLMSDbContext context)
        {
            _context = context;
        }

        public List<Student> Students { get;set; }

        // public void OnGet()             // OnGet or OnGetAsync...need async version only if awaiting async methods
        public async Task OnGetAsync()
        {
            Students = await _context.Students.ToListAsync();
        }
    }
}
