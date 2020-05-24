using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActivityTracker.Models
{
    public class Unit
	{
		public int UnitId { get; set; }

		[Required, MaxLength(100), Display(Name = "Unit name")]
		public string UnitName { get; set; }

		public List<Activity> Activities { get; set; }
	}
}
