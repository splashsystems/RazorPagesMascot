using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Schools { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MascotSchool { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> schoolQuery = from s in _context.Mascot
                                            orderby s.School
                                            select s.School;
            var mascots = from m in _context.Mascot
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                mascots = mascots.Where(s => s.MascotName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MascotSchool))
            {
                mascots = mascots.Where(x => x.School == MascotSchool);
            }
            Schools = new SelectList(await schoolQuery.Distinct().ToListAsync());
            
            Mascot = await mascots.ToListAsync();
        }
        
        
    }
}
