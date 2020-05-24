using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActivityTracker.Models
{
    public class CustomUnit
	{
		public int CustomUnitId { get; set; }
		public string UserId { get; set; }

		[Required, MaxLength(100), Display(Name = "Custom unit name")]
		public string CustomUnitName { get; set; }

		public List<Activity> Activities { get; set; }
	}
}
