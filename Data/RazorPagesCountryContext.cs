using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesCountry.Models;

namespace RazorPagesCountry.Data
{
    public class RazorPagesCountryContext : DbContext
    {
        public RazorPagesCountryContext (DbContextOptions<RazorPagesCountryContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesCountry.Models.Country> Country { get; set; } = default!;
    }
}
