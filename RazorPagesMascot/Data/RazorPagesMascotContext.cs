using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMascot.Models;

namespace RazorPagesMascot.Data
{
    public class RazorPagesMascotContext : DbContext
    {
        public RazorPagesMascotContext (DbContextOptions<RazorPagesMascotContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMascot.Models.Mascot> Mascot { get; set; }
    }
}
