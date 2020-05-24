using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActivityTracker.Data;
using ActivityTracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace ActivityTracker.Pages.ActivityLogs
{
    public class CreateModel : PageModel
    {
        private readonly ActivityTrackerContext _context;

        public CreateModel(ActivityTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "ActivityName");
            Activities = _context.Activity.ToList();
            ViewData["strActivities"] = string.Join("|", Activities.Select(x => x.ActivityId + "#" + x.PointsPerUnit + "#" + x.MaxPointsPerDay));

            return Page();
        }

        [BindProperty]
        public ActivityLog ActivityLog { get; set; }

        [BindProperty]
        public IList<Activity> Activities { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "ActivityName");
                Activities = _context.Activity.ToList();

                return Page();
            }

            _context.ActivityLog.Add(ActivityLog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
