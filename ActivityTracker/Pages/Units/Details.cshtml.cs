using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivityTracker.Data;
using ActivityTracker.Models;

namespace ActivityTracker.Pages.Units
{
    public class DetailsModel : PageModel
    {
        private readonly ActivityTracker.Data.ActivityTrackerContext _context;

        public DetailsModel(ActivityTracker.Data.ActivityTrackerContext context)
        {
            _context = context;
        }

        public Unit Unit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Unit = await _context.Unit.FirstOrDefaultAsync(m => m.UnitId == id);

            if (Unit == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
