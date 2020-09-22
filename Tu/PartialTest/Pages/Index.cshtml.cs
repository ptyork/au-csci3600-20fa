using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PartialTest.Models;

namespace PartialTest.Pages
{
    public class IndexModel : PageModel
    {
        public List<Book> Books { get; set; } = new List<Book>();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

            Books.Add(new Book() { 
                Title = "A Boy Who Could Type",
                Author = "Not Paul",
                PageCount = 10,
                ISBN = "1234567-890"
            });
            
            var b = new Book();
            b.Title = "A Longer Book";
            b.Author = "Not Paul";
            b.PageCount = 20;
            b.ISBN = "234678-901";
            Books.Add(b);
        }

        // public void OnGet()
        // {

        // }
    }
}
