using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivityTracker.Data;
using ActivityTracker.Models;
using System.Linq;
using System;

namespace ActivityTracker.Pages.Activities
{
    public class IndexModel : PageModel
    {
        private readonly ActivityTrackerContext _context;

        public IndexModel(ActivityTrackerContext context)
        {
            _context = context;
        }

        public IList<Activity> Activity { get; set; }


        public string ActivityNameSort { get; set; }
        public string PointsPerUnitSort { get; set; }
        public string MaxPointsPerDaySort { get; set; }
        public string ValidFromSort { get; set; }
        public string ValidToSort { get; set; }
        public string UnitSort { get; set; }
        public string CustomUnitSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            ActivityNameSort = sortOrder == null || sortOrder == "ActivityName" ? "ActivityName_desc" : "ActivityName";
            PointsPerUnitSort = sortOrder == "PointsPerUnit" ? "PointsPerUnit_desc" : "PointsPerUnit";
            MaxPointsPerDaySort = sortOrder == "MaxPointsPerDay" ? "MaxPointsPerDay_desc" : "MaxPointsPerDay";
            ValidFromSort = sortOrder == "ActivityValidFrom" ? "ActivityValidFrom_desc" : "ActivityValidFrom";
            ValidToSort = sortOrder == "ActivityValidTo" ? "ActivityValidTo_desc" : "ActivityValidTo";
            UnitSort = sortOrder == "Unit" ? "Unit_desc" : "Unit";
            CustomUnitSort = sortOrder == "CustomUnit" ? "CustomUnit_desc" : "CustomUnit";

            IQueryable<Activity> activities = _context.Activity
                .Include(a => a.CustomUnit)
                .Include(a => a.Unit);

            switch (sortOrder)
            {
                case "ActivityName":
                    activities = activities.OrderBy(a => a.ActivityName);
                    break;
                case "ActivityName_desc":
                    activities = activities.OrderByDescending(a => a.ActivityName);
                    break;
                case "PointsPerUnit":
                    activities = activities.OrderBy(a => a.PointsPerUnit);
                    break;
                case "PointsPerUnit_desc":
                    activities = activities.OrderByDescending(a => a.PointsPerUnit);
                    break;
                case "MaxPointsPerDay":
                    activities = activities.OrderBy(a => a.MaxPointsPerDay);
                    break;
                case "MaxPointsPerDay_desc":
                    activities = activities.OrderByDescending(a => a.MaxPointsPerDay);
                    break;
                case "ActivityValidFrom":
                    activities = activities.OrderBy(a => a.ActivityValidFrom);
                    break;
                case "ActivityValidFrom_desc":
                    activities = activities.OrderByDescending(a => a.ActivityValidFrom);
                    break;
                case "ActivityValidTo":
                    activities = activities.OrderBy(a => a.ActivityValidTo);
                    break;
                case "ActivityValidTo_desc":
                    activities = activities.OrderByDescending(a => a.ActivityValidTo);
                    break;
                case "Unit":
                    activities = activities.OrderBy(a => a.Unit.UnitName);
                    break;
                case "Unit_desc":
                    activities = activities.OrderByDescending(a => a.Unit.UnitName);
                    break;
                case "CustomUnit":
                    activities = activities.OrderBy(a => a.CustomUnit.CustomUnitName);
                    break;
                case "CustomUnit_desc":
                    activities = activities.OrderByDescending(a => a.CustomUnit.CustomUnitName);
                    break;
                default:
                    activities = activities
                        .OrderBy(a => (a.ActivityValidFrom <= DateTime.Today && a.ActivityValidTo >= DateTime.Today ? 1 : 2)).ThenBy(a => a.ActivityName);
                    break;
            }

            Activity = await activities.AsNoTracking().ToListAsync();
        }
    }
}
