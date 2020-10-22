using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MiniLMS.Pages
{
    public class FunControlsModel : PageModel
    {
        public void OnGet()
        {
        }

        // Need to use model binding as I'd feared
        // https://www.learnrazorpages.com/razor-pages/forms/checkboxes
        [BindProperty]
        public bool IsAlien { get; set; }

        [BindProperty]
        public string FavColor { get; set; }

        public void OnPost()
        {
        }
    }
}
