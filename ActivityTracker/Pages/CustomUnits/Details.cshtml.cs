using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivityTracker.Data;
using ActivityTracker.Models;

namespace ActivityTracker.Pages.CustomUnits
{
    public class DetailsModel : PageModel
    {
        private readonly ActivityTracker.Data.ActivityTrackerContext _context;

        public DetailsModel(ActivityTracker.Data.ActivityTrackerContext context)
        {
            _context = context;
        }

        public CustomUnit CustomUnit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomUnit = await _context.CustomUnit.FirstOrDefaultAsync(m => m.CustomUnitId == id);

            if (CustomUnit == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
