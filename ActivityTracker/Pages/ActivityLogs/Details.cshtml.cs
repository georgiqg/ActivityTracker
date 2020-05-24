using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivityTracker.Data;
using ActivityTracker.Models;

namespace ActivityTracker.Pages.ActivityLogs
{
    public class DetailsModel : PageModel
    {
        private readonly ActivityTrackerContext _context;

        public DetailsModel(ActivityTrackerContext context)
        {
            _context = context;
        }

        public ActivityLog ActivityLog { get; set; }

        [BindProperty]
        public string UnitName { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ActivityLog = await _context.ActivityLog
                .Include(a => a.Activity)
                .Include(a => a.Activity.Unit)
                .FirstOrDefaultAsync(m => m.ActivityLogId == id);

            if (ActivityLog == null)
            {
                return NotFound();
            }

            ActivityLog.SetTotalPoints();
            UnitName = ActivityLog.Activity.GetUnitName();

            return Page();
        }
    }
}
