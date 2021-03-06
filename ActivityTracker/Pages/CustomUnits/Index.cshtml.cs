using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivityTracker.Data;
using ActivityTracker.Models;
using System.Linq;

namespace ActivityTracker.Pages.CustomUnits
{
    public class IndexModel : PageModel
    {
        private readonly ActivityTrackerContext _context;

        public IndexModel(ActivityTrackerContext context)
        {
            _context = context;
        }

        public IList<CustomUnit> CustomUnit { get;set; }

        public string CustomUnitNameSort { get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            // Properties used to toggle between ascending and descending order
            CustomUnitNameSort = sortOrder == null || sortOrder == "CustomUnitNameSort" ? "CustomUnitNameSort_desc" : "CustomUnitNameSort";

            CurrentFilter = searchString;

            var customUnits = _context.CustomUnit
                .Where(cu => string.IsNullOrWhiteSpace(CurrentFilter) || cu.CustomUnitName.Contains(CurrentFilter))
                .AsQueryable();

            switch (sortOrder)
            {
                case "CustomUnitNameSort":
                    customUnits = customUnits.OrderBy(cu => cu.CustomUnitName);
                    break;
                case "CustomUnitNameSort_desc":
                    customUnits = customUnits.OrderByDescending(cu => cu.CustomUnitName);
                    break;
                default:
                    customUnits = customUnits.OrderBy(cu => cu.CustomUnitName);
                    break;
            }

            CustomUnit = await customUnits.AsNoTracking().ToListAsync();
        }
    }
}
