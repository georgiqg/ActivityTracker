using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivityTracker.Data;
using ActivityTracker.Models;
using System.Linq;
using System;

namespace ActivityTracker.Pages.Activities
{
    public class IndexModel : PageModel
    {
        private readonly ActivityTrackerContext _context;

        public IndexModel(ActivityTrackerContext context)
        {
            _context = context;
        }

        public IList<Activity> Activity { get;set; }

        public async Task OnGetAsync()
        {
            Activity = await _context.Activity
                .Include(a => a.CustomUnit)
                .Include(a => a.Unit)
                .OrderBy(a => (a.ActivityValidFrom <= DateTime.Today && a.ActivityValidTo >= DateTime.Today ? 1 : 2))
                .ThenBy(a => a.ActivityName)
                .ToListAsync();
        }
    }
}
