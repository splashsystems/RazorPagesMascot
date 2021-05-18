using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMascot.Data;
using RazorPagesMascot.Models;

namespace RazorPagesMascot.Pages.Mascots
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMascot.Data.RazorPagesMascotContext _context;

        public IndexModel(RazorPagesMascot.Data.RazorPagesMascotContext context)
        {
            _context = context;
        }

        public IList<Mascot> Mascot { get;set; }

        public async Task OnGetAsync()
        {
            Mascot = await _context.Mascot.ToListAsync();
        }
    }
}
