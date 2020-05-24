using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivityTracker.Data;
using ActivityTracker.Models;

namespace ActivityTracker.Pages.ActivityLogs
{
    public class IndexModel : PageModel
    {
        private readonly ActivityTracker.Data.ActivityTrackerContext _context;

        public IndexModel(ActivityTracker.Data.ActivityTrackerContext context)
        {
            _context = context;
        }

        public IList<ActivityLog> ActivityLog { get;set; }

        public async Task OnGetAsync()
        {
            ActivityLog = await _context.ActivityLog
                .Include(a => a.Activity).ToListAsync();
        }
    }
}
