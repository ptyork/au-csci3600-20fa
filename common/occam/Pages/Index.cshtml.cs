using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace occam
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet=true)]
        public string Name { get; set; } = "Anonymous";

        public List<string> Peeps { get; set; }

        public IActionResult OnGet()
        {
            Peeps = new List<string>() {
                "John",
                "Paul",
                "George",
                "Ringo"
            };

            return NotFound();
            //return RedirectToPage("Stuff");
            //return Page();
        }
    }
}
