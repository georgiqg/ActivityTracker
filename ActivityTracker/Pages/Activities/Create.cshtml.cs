﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActivityTracker.Data;
using ActivityTracker.Models;

namespace ActivityTracker.Pages.Activities
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
            ViewData["CustomUnitId"] = new SelectList(_context.Set<CustomUnit>(), "CustomUnitId", "CustomUnitName");
            ViewData["UnitId"] = new SelectList(_context.Set<Unit>(), "UnitId", "UnitName");
            return Page();
        }

        [BindProperty]
        public Activity Activity { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["CustomUnitId"] = new SelectList(_context.Set<CustomUnit>(), "CustomUnitId", "CustomUnitName");
                ViewData["UnitId"] = new SelectList(_context.Set<Unit>(), "UnitId", "UnitName");
                return Page();
            }

            _context.Activity.Add(Activity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
