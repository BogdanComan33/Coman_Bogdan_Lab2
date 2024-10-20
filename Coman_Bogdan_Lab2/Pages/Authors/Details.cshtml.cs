﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coman_Bogdan_Lab2.Data;
using Coman_Bogdan_Lab2.Models;

namespace Coman_Bogdan_Lab2.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly Coman_Bogdan_Lab2.Data.Coman_Bogdan_Lab2Context _context;

        public DetailsModel(Coman_Bogdan_Lab2.Data.Coman_Bogdan_Lab2Context context)
        {
            _context = context;
        }

        public Publisher Publisher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);
            if (publisher == null)
            {
                return NotFound();
            }
            else
            {
                Publisher = publisher;
            }
            return Page();
        }
    }
}
