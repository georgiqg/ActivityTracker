using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivityTracker.Data;
using ActivityTracker.Models;

namespace ActivityTracker.Pages.ActivityLogs
{
    public class IndexModel : PageModel
    {
        private readonly ActivityTrackerContext _context;

        public IndexModel(ActivityTrackerContext context)
        {
            _context = context;
        }

        public IList<ActivityLog> ActivityLog { get; set; }

        public string LogDateSort { get; set; }
        public string ActivitySort { get; set; }
        public string UnitsSort { get; set; }
        public string UnitNameSort { get; set; }
        public string TotalPointsSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            // Properties used to toggle between ascending and descending order
            LogDateSort = sortOrder == null || sortOrder == "LogDateSort_desc" ? "LogDateSort" : "LogDateSort_desc";
            ActivitySort = sortOrder == "ActivitySort" ? "ActivitySort_desc" : "ActivitySort";
            UnitsSort = sortOrder == "UnitsSort" ? "UnitsSort_desc" : "UnitsSort";
            UnitNameSort = sortOrder == "UnitNameSort" ? "UnitNameSort_desc" : "UnitNameSort";
            TotalPointsSort = sortOrder == "TotalPointsSort" ? "TotalPointsSort_desc" : "TotalPointsSort";

            var activitiesList = _context.ActivityLog
                .Include(a => a.Activity)
                .Include(a => a.Activity.Unit)
                .Include(a => a.Activity.CustomUnit).AsNoTracking().ToList();

            // Setting the NotMapped properties inside ActivityLog and Activity. I'm doing it here to be able to order by those fields later
            activitiesList.ForEach(a => { a.SetTotalPoints(); a.Activity.SetUnitName(); });

            // Need an IQueryable collection in order to perform the OrderBy
            var queryableActivities = activitiesList.ToList().AsQueryable();

            switch (sortOrder)
            {
                case "LogDateSort":
                    queryableActivities = queryableActivities.OrderBy(a => a.LogDate).ThenBy(a => a.Activity.ActivityName);
                    break;
                case "LogDateSort_desc":
                    queryableActivities = queryableActivities.OrderByDescending(a => a.LogDate).ThenBy(a => a.Activity.ActivityName);
                    break;
                case "ActivitySort":
                    queryableActivities = queryableActivities.OrderBy(a => a.Activity.ActivityName).ThenBy(a => a.LogDate);
                    break;
                case "ActivitySort_desc":
                    queryableActivities = queryableActivities.OrderByDescending(a => a.Activity.ActivityName).ThenByDescending(a => a.LogDate);
                    break;
                case "UnitsSort":
                    queryableActivities = queryableActivities.OrderBy(a => a.Units).ThenByDescending(a => a.LogDate);
                    break;
                case "UnitsSort_desc":
                    queryableActivities = queryableActivities.OrderByDescending(a => a.Units).ThenByDescending(a => a.LogDate);
                    break;
                case "UnitNameSort":
                    queryableActivities = queryableActivities.OrderBy(a => a.Activity.UnitName).ThenByDescending(a => a.LogDate);
                    break;
                case "UnitNameSort_desc":
                    queryableActivities = queryableActivities.OrderByDescending(a => a.Activity.UnitName).ThenByDescending(a => a.LogDate);
                    break;
                case "TotalPointsSort":
                    queryableActivities = queryableActivities.OrderBy(a => a.TotalPoints).ThenByDescending(a => a.LogDate);
                    break;
                case "TotalPointsSort_desc":
                    queryableActivities = queryableActivities.OrderByDescending(a => a.TotalPoints).ThenByDescending(a => a.LogDate);
                    break;
                default:
                    queryableActivities = queryableActivities.OrderByDescending(a => a.LogDate).ThenBy(a => a.Activity.ActivityName);
                    break;
            }

            ActivityLog = await Task.FromResult(queryableActivities.ToList());
        }
    }
}
