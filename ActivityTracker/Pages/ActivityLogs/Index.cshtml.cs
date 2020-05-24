using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivityTracker.Data;
using ActivityTracker.Models;

namespace ActivityTracker.Pages.ActivityLogs
{
    public class IndexModel : PageModel
    {
        private readonly ActivityTrackerContext _context;

        public IndexModel(ActivityTrackerContext context)
        {
            _context = context;
        }

        public IList<ActivityLog> ActivityLog { get; set; }

        public async Task OnGetAsync()
        {
            ActivityLog = await _context.ActivityLog
                .Include(a => a.Activity)
                .Include(a => a.Activity.Unit)
                .Include(a => a.Activity.CustomUnit)
                .OrderByDescending(a => a.LogDate)
                .ThenBy(a => a.Activity.ActivityName)
                .ToListAsync();

            ActivityLog.ToList()
                .ForEach(a => a.SetTotalPoints());

            ActivityLog.ToList().ForEach(a => a.Activity.SetUnitName());
        }
    }
}
