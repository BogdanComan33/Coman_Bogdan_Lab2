using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coman_Bogdan_Lab2.Data;
using Coman_Bogdan_Lab2.Models;

namespace Coman_Bogdan_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Coman_Bogdan_Lab2.Data.Coman_Bogdan_Lab2Context _context;

        public IndexModel(Coman_Bogdan_Lab2.Data.Coman_Bogdan_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public IList<Book> Books { get; set; } = default!;
        public int? SelectedCategoryID { get; set; }

        

    

        public async Task OnGetAsync(int? categoryId)
        {
            Category = await _context.Category.ToListAsync();

            if (categoryId.HasValue)
            {
                SelectedCategoryID = categoryId;
                Books = await _context.Book
                    .Include(b => b.Author)
                    .Include(b => b.BookCategories)
                    .Where(b => b.BookCategories.Any(bc => bc.CategoryID == categoryId))
                    .ToListAsync();
            }


        }
    }
}
