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
    public class IndexModel : PageModel
    {
        private readonly Coman_Bogdan_Lab2.Data.Coman_Bogdan_Lab2Context _context;

        public IndexModel(Coman_Bogdan_Lab2.Data.Coman_Bogdan_Lab2Context context)
        {
            _context = context;
        }

        public IList<Author> Authors { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Authors = await _context.Authors.ToListAsync();
        }
    }
}
