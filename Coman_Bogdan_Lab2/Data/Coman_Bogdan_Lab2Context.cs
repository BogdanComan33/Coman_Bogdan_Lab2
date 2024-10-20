using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Coman_Bogdan_Lab2.Models;

namespace Coman_Bogdan_Lab2.Data
{
    public class Coman_Bogdan_Lab2Context : DbContext
    {
        public Coman_Bogdan_Lab2Context (DbContextOptions<Coman_Bogdan_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Coman_Bogdan_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Coman_Bogdan_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    }
}
