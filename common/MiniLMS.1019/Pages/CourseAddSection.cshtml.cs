using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniLMS.Data;
using MiniLMS.Models;

namespace MiniLMS.Pages
{
    public class CourseAddSectionModel : PageModel
    {
        private readonly MiniLMS.Data.MiniLMSDbContext _context;

        public CourseAddSectionModel(MiniLMS.Data.MiniLMSDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Section Section { get; set; }

        // add a second property for the actual course...note it is NOT bound because I'm
        // just using this to display the course details
        public Course Course { get; set; }

        public IActionResult OnGet(int? id)
        {
            // rework to load in a course in order to display it's details prior to
            // adding the section to it
            if (id == null)
            {
                return NotFound();
            }
            
            Course = _context.Courses.FirstOrDefault(c => c.CourseId == id);

            if (Course == null)
            {
                return NotFound();
            }

            // NOT using the ViewData object to store the id since I have the whole
            // Course as a model object now
            // ViewData["CourseId"] = id;
            ViewData["InstructorId"] = GetSelectListItems();

            return Page();
        }

        // adding a method for this since I use it in two places
        private List<SelectListItem> GetSelectListItems()
        {
            // Here's I'm going to manually construct my SelectList to use when displaying
            // this instructor selection. This is nice since I can now also add a
            // "Not Assigned" option.
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem("Not Assigned", "0"));
            foreach (var inst in _context.Instructors)
            {
                items.Add(new SelectListItem(inst.FullName, inst.InstructorId.ToString()));
            }
            return items;
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // need to recreate the Course object AND the list of instructors before
                // showing the page if we have errors
                Course = _context.Courses.FirstOrDefault(c => c.CourseId == Section.CourseId);
                ViewData["InstructorId"] = GetSelectListItems();
                return Page();
            }

            _context.Sections.Add(Section);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
