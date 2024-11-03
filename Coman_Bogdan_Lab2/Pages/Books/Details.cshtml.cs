using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coman_Bogdan_Lab2.Data;
using Coman_Bogdan_Lab2.Models;

namespace Coman_Bogdan_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Coman_Bogdan_Lab2.Data.Coman_Bogdan_Lab2Context _context;

        public DetailsModel(Coman_Bogdan_Lab2.Data.Coman_Bogdan_Lab2Context context)
        {
            _context = context;
        }

        public Models.Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        }
    }
}
