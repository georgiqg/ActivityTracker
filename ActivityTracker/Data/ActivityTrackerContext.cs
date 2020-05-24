using Microsoft.EntityFrameworkCore;
using ActivityTracker.Models;

namespace ActivityTracker.Data
{
    public class ActivityTrackerContext : DbContext
    {
        public ActivityTrackerContext(DbContextOptions<ActivityTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Activity> Activity { get; set; }

        public DbSet<Unit> Unit { get; set; }

        public DbSet<CustomUnit> CustomUnit { get; set; }

        public DbSet<ActivityLog> ActivityLog { get; set; }
    }
}
