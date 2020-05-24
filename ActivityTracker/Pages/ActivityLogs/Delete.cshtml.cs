using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivityTracker.Data;
using ActivityTracker.Models;

namespace ActivityTracker.Pages.ActivityLogs
{
    public class DeleteModel : PageModel
    {
        private readonly ActivityTrackerContext _context;

        public DeleteModel(ActivityTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ActivityLog ActivityLog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ActivityLog = await _context.ActivityLog
                .Include(a => a.Activity).FirstOrDefaultAsync(m => m.ActivityLogId == id);

            if (ActivityLog == null)
            {
                return NotFound();
            }

            ActivityLog.SetTotalPoints();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ActivityLog = await _context.ActivityLog.FindAsync(id);

            if (ActivityLog != null)
            {
                _context.ActivityLog.Remove(ActivityLog);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
