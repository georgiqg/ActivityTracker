using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActivityTracker.Data;
using ActivityTracker.Models;
using System.Collections.Generic;

namespace ActivityTracker.Pages.ActivityLogs
{
    public class EditModel : PageModel
    {
        private readonly ActivityTrackerContext _context;

        public EditModel(ActivityTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ActivityLog ActivityLog { get; set; }

        public IList<Activity> Activities { get; set; }

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

            ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "ActivityName");
            Activities = _context.Activity.ToList();
            ViewData["strActivities"] = string.Join("|", Activities.Select(x => x.ActivityId + "#" + x.PointsPerUnit + "#" + x.MaxPointsPerDay));

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ActivityLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityLogExists(ActivityLog.ActivityLogId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ActivityLogExists(int id)
        {
            return _context.ActivityLog.Any(e => e.ActivityLogId == id);
        }
    }
}
