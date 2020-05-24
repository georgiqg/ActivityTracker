using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ActivityTracker.Models;

namespace ActivityTracker.Data
{
    public class ActivityTrackerContext : DbContext
    {
        public ActivityTrackerContext (DbContextOptions<ActivityTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<ActivityTracker.Models.Activity> Activity { get; set; }

        public DbSet<ActivityTracker.Models.Unit> Unit { get; set; }

        public DbSet<ActivityTracker.Models.CustomUnit> CustomUnit { get; set; }

        public DbSet<ActivityTracker.Models.ActivityLog> ActivityLog { get; set; }
    }
}
