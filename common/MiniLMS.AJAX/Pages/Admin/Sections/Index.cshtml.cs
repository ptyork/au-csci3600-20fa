﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly MiniLMS.Data.MiniLMSDbContext _context;

        public IndexModel(MiniLMS.Data.MiniLMSDbContext context)
        {
            _context = context;
        }

        public IList<Section> Section { get;set; }

        public async Task OnGetAsync()
        {
            Section = await _context.Sections
                .Include(s => s.Course)
                .Include(s => s.Instructor).ToListAsync();
        }
    }
}
