using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivityTracker.Data;
using ActivityTracker.Models;
using System.Linq;

namespace ActivityTracker.Pages.Units
{
    public class IndexModel : PageModel
    {
        private readonly ActivityTrackerContext _context;

        public IndexModel(ActivityTrackerContext context)
        {
            _context = context;
        }

        public IList<Unit> Unit { get;set; }

        public string UnitNameSort { get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            // Properties used to toggle between ascending and descending order
            UnitNameSort = sortOrder == null || sortOrder == "UnitNameSort" ? "UnitNameSort_desc" : "UnitNameSort";

            CurrentFilter = searchString;

            var units = _context.Unit
                .Where(u => string.IsNullOrWhiteSpace(CurrentFilter) || u.UnitName.Contains(CurrentFilter))
                .AsQueryable();

            switch (sortOrder)
            {
                case "UnitNameSort":
                    units = units.OrderBy(u => u.UnitName);
                    break;
                case "UnitNameSort_desc":
                    units = units.OrderByDescending(u => u.UnitName);
                    break;
                default:
                    units = units.OrderBy(u => u.UnitName);
                    break;
            }

            Unit = await units.AsNoTracking().ToListAsync();
        }
    }
}
