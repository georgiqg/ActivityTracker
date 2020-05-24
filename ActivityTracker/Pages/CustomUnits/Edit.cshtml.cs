using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActivityTracker.Data;
using ActivityTracker.Models;

namespace ActivityTracker.Pages.CustomUnits
{
    public class EditModel : PageModel
    {
        private readonly ActivityTracker.Data.ActivityTrackerContext _context;

        public EditModel(ActivityTracker.Data.ActivityTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CustomUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomUnitExists(CustomUnit.CustomUnitId))
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

        private bool CustomUnitExists(int id)
        {
            return _context.CustomUnit.Any(e => e.CustomUnitId == id);
        }
    }
}
