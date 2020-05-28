using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActivityTracker.Data;
using ActivityTracker.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

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
            Activities = _context.Activity
                .Where(a => a.ActivityValidFrom <= DateTime.Today && a.ActivityValidTo >= DateTime.Today)
                .Include(a => a.Unit)
                .Include(a => a.CustomUnit)
                .OrderBy(a => a.ActivityName)
                .ToList();

            Activities.ToList().ForEach(a => a.SetUnitName());
            ViewData["ActivityId"] = new SelectList(Activities, "ActivityId", "ActivityName");
            ViewData["strActivities"] = string.Join("|", Activities.Select(x => x.ActivityId + "#" + x.PointsPerUnit + "#" + x.MaxPointsPerDay + "#" + x.UnitName));

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
            ValidateData();

            if (!ModelState.IsValid)
            {
                Activities = _context.Activity
                    .Where(a => a.ActivityValidFrom <= DateTime.Today && a.ActivityValidTo >= DateTime.Today)
                    .Include(a => a.Unit)
                    .OrderBy(a => a.ActivityName)
                    .ToList();

                Activities.ToList().ForEach(a => a.SetUnitName());
                ViewData["ActivityId"] = new SelectList(Activities, "ActivityId", "ActivityName");
                ViewData["strActivities"] = string.Join("|", Activities.Select(x => x.ActivityId + "#" + x.PointsPerUnit + "#" + x.MaxPointsPerDay + "#" + x.UnitName));

                return Page();
            }

            _context.ActivityLog.Add(ActivityLog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public void ValidateData()
        {
            var alreadyAdded = _context.ActivityLog
                .Where(a => a.UserId == ActivityLog.UserId
                    && a.ActivityId == ActivityLog.ActivityId
                    && a.LogDate == ActivityLog.LogDate
                    && a.ActivityLogId != ActivityLog.ActivityLogId);

            if (alreadyAdded.Any())
            {
                ModelState.AddModelError("ActivityLog.ActivityId", "You already have the selected activity for that date.");
            }
        }
    }
}
