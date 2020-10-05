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
    public class IndexModel : PageModel
    {
        // INSTANCE VARIABLES
        private readonly ILogger<IndexModel> _logger;
        private readonly MiniLMSDbContext _dbContext;

        // PROPERTIES
        public List<Course> Courses { get; set; } = new List<Course>();

        public IndexModel(ILogger<IndexModel> logger, MiniLMSDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            this.Courses.AddRange(
                _dbContext.Courses.Include(c => c.Sections)
            );
        }
    }
}
